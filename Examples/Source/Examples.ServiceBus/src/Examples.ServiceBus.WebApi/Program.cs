﻿using Destructurama;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using Examples.ServiceBus.App.Plugin;
using Examples.ServiceBus.Domain.Plugin;
using Examples.ServiceBus.WebApi.Plugin;
using System.Diagnostics;
using Examples.ServiceBus.Infra.Plugin;
using NetFusion.Common.Base.Serialization;
using NetFusion.Core.Bootstrap.Container;
using NetFusion.Core.Builder;
using NetFusion.Core.Settings.Plugin;
using NetFusion.Integration.ServiceBus.Plugin;
using NetFusion.Integration.ServiceBus.Plugin.Configs;
using NetFusion.Messaging.Plugin.Configs;
using NetFusion.Services.Messaging.Enrichers;
using NetFusion.Services.Serialization;
using NetFusion.Services.Serilog;

// Allows changing the minimum log level of the service at runtime.
LogLevelControl logLevelControl = new();
logLevelControl.SetMinimumLevel(LogLevel.Debug);

var builder = WebApplication.CreateBuilder(args);

// Configure Logging:
InitializeLogger(builder.Configuration);

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger);
builder.Host.UseSerilog();

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

// Register Log Level Control so it can be injected into
// a service at runtime to change the level.
builder.Services.AddLogLevelControl(logLevelControl);

try
{
    // Add Plugins to the Composite-Container:
    builder.Services.CompositeContainer(builder.Configuration, new SerilogExtendedLogger())
        .AddSettings()
        
        .AddAzureServiceBus()
        .InitPluginConfig((ServiceBusConfig c) => c.IsAutoCreateEnabled = true)
        .InitPluginConfig<MessageDispatchConfig>(c =>
        {
            c.AddEnricher<CorrelationEnricher>();
            c.AddEnricher<DateOccurredEnricher>();
            c.AddEnricher<HostEnricher>();
        })
        
        .AddPlugin<InfraPlugin>()
        .AddPlugin<AppPlugin>()
        .AddPlugin<DomainPlugin>()
        .AddPlugin<WebApiPlugin>()
        .Compose(s =>
        { 
            s.AddSingleton<ISerializationManager, SerializationManager>();
        });
}
catch
{
    Log.CloseAndFlush();
}

var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseRouting();
app.MapControllers();

// Reference the Composite-Application to start the plugins then
// start the web application.
var compositeApp = app.Services.GetRequiredService<ICompositeApp>();
var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();

lifetime.ApplicationStopping.Register(() =>
{
    compositeApp.Stop();
    Log.CloseAndFlush();
});

await compositeApp.StartAsync();
await app.RunAsync();

void InitializeLogger(IConfiguration configuration)
{
    // Send any Serilog configuration issues logs to console.
    Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
    Serilog.Debugging.SelfLog.Enable(Console.Error);

    var logConfig = new LoggerConfiguration()
        .MinimumLevel.ControlledBy(logLevelControl.Switch)
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
        .Destructure.UsingAttributes()

        .Enrich.FromLogContext()
        .Enrich.WithCorrelationId()
        .Enrich.WithHostIdentity(WebApiPlugin.HostId, WebApiPlugin.HostName)
        .Filter.SuppressReoccurringRequestEvents();

    logConfig.WriteTo.Console(theme: AnsiConsoleTheme.Literate);

    var seqUrl = configuration.GetValue<string>("logging:seqUrl");
    if (!string.IsNullOrEmpty(seqUrl))
    {
        logConfig.WriteTo.Seq(seqUrl);
    }

    Log.Logger = logConfig.CreateLogger();
}

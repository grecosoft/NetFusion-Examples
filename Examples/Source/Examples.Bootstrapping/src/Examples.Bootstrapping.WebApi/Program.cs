﻿using Examples.Bootstrapping.App.Plugin;
using Examples.Bootstrapping.App.Plugin.Configs;
using Examples.Bootstrapping.CrossCut.Plugin;
using Examples.Bootstrapping.Domain.Plugin;
using Examples.Bootstrapping.Infra.Plugin;
using Examples.Bootstrapping.WebApi.Plugin;
using NetFusion.Core.Settings.Plugin;

// Allows changing the minimum log level of the service at runtime.
LogLevelControl logLevelControl = new();
logLevelControl.SetMinimumLevel(LogLevel.Debug);

var builder = WebApplication.CreateBuilder(args);

// Configure Logging:
InitializeLogger(builder.Configuration);

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger);
builder.Host.UseSerilog();

builder.Services.AddCors();
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
        
        .AddPlugin<CrossCutPlugin>()

        .AddPlugin<InfraPlugin>()
        .AddPlugin<AppPlugin>()
        .AddPlugin<DomainPlugin>()
        .AddPlugin<WebApiPlugin>()
        
        .InitPluginConfig((HelloWorldConfig config) => config.SetMessage("is anyone home?"))
        .Compose();
}
catch
{
    Log.CloseAndFlush();
}

var app = builder.Build();

string? viewerUrl = app.Configuration.GetValue<string>("Netfusion:ViewerUrl");
if (!string.IsNullOrWhiteSpace(viewerUrl))
{
    app.UseCors(cors => cors.WithOrigins(viewerUrl)
        .AllowAnyMethod()
        .AllowCredentials()
        .WithExposedHeaders("WWW-Authenticate", "resource-404")
        .AllowAnyHeader());
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapCompositeLog();
}


// Reference the Composite-Application to start the plugins then
// start the web application.
var compositeApp = app.Services.GetRequiredService<ICompositeApp>();
var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();

lifetime.ApplicationStopping.Register(() =>
{
    compositeApp.Stop();
    Log.CloseAndFlush();
});

var runTask = app.RunAsync();
await compositeApp.StartAsync();
await runTask;

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

using NetFusion.Bootstrap.Container;
using NetFusion.Serilog;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Diagnostics;
using Demo.App.Plugin;
using Demo.Domain.Plugin;
using Demo.Infra;
using Demo.Infra.Plugin;
using Demo.WebApi.Plugin;
using NetFusion.Builder;
using NetFusion.Messaging.Plugin;
using NetFusion.Messaging.Plugin.Configs;


var builder = WebApplication.CreateBuilder(args);

InitializeLogger(builder.Configuration);

builder.Host.ConfigureAppConfiguration(SetupConfiguration);
builder.Host.ConfigureLogging(SetupLogging);
builder.Host.UseSerilog();

builder.Services.AddControllers();

try
{
    // Add Plugins to the Composite-Container:
    builder.Services.CompositeContainer(builder.Configuration, new SerilogExtendedLogger())
        .AddMessaging()

        //.InitPluginConfig<MessageDispatchConfig>(config =>
        //{
        //    config.ClearPublishers();
        //    config.AddPublisher<ExamplePublisher>();
        //})

        .InitPluginConfig<MessageDispatchConfig>(config =>
        {
            config.ClearPublishers();
            config.AddEnricher<MachineNameEnricher>();
        })
    
        .InitPluginConfig<QueryDispatchConfig>(c =>
        {
            c.AddFilter<TimeQueryFilter>();
        })

        .AddPlugin<InfraPlugin>()
        .AddPlugin<AppPlugin>()
        .AddPlugin<DomainPlugin>()
        .AddPlugin<WebApiPlugin>()
        .Compose();
}
catch
{
    Log.CloseAndFlush();
}

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
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
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)

        .Enrich.FromLogContext()
        .Enrich.WithCorrelationId()
        .Enrich.WithHostIdentity(WebApiPlugin.HostId, WebApiPlugin.HostName);

    logConfig.WriteTo.Console(theme: AnsiConsoleTheme.Literate);

    var seqUrl = configuration.GetValue<string>("logging:seqUrl");
    if (!string.IsNullOrEmpty(seqUrl))
    {
        logConfig.WriteTo.Seq(seqUrl);
    }

    Log.Logger = logConfig.CreateLogger();
}

void SetupConfiguration(HostBuilderContext context, IConfigurationBuilder configBuilder)
{
    
}

static void SetupLogging(HostBuilderContext context, ILoggingBuilder builder)
{
    builder.ClearProviders();
    builder.AddSerilog(Log.Logger);
}
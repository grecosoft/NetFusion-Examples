using App.Component.Plugin;
using App.Component.Plugin.Configs;
using Core.Component.Plugin;
using NetFusion.Bootstrap.Container;
using NetFusion.Builder;
using NetFusion.Serilog;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Diagnostics;
using WebApiHost.Plugin;


var builder = WebApplication.CreateBuilder(args);


builder.Host.ConfigureLogging(SetupLogging);
builder.Host.UseSerilog();


builder.Services.AddControllers();


// Add Plugins to the Composite-Container:
builder.Services.CompositeContainer(builder.Configuration, new SerilogExtendedLogger()) 
    .AddPlugin<CorePlugin>()
    .AddPlugin<AppPlugin>()
    .AddPlugin<WebApiPlugin>()
    .InitPluginConfig((HelloWorldConfig config) => config.SetMessage("is anyone home?"))
    .Compose();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseSerilogRequestLogging();     

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



static void SetupLogging(HostBuilderContext context,
            ILoggingBuilder builder)
{
    var seqUrl = context.Configuration.GetValue<string>("logging:seqUrl");

    // Send any Serilog configuration issue logs to console.
    Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
    Serilog.Debugging.SelfLog.Enable(Console.Error);

    var logConfig = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)

        .Enrich.FromLogContext()
        .Enrich.WithCorrelationId()
        .Enrich.WithHostIdentity(WebApiPlugin.HostId, WebApiPlugin.HostName);

    logConfig.WriteTo.Console(theme: AnsiConsoleTheme.Literate);

    if (!string.IsNullOrEmpty(seqUrl))
    {
        logConfig.WriteTo.Seq(seqUrl);
    }

    Log.Logger = logConfig.CreateLogger();

    builder.ClearProviders();
    builder.AddSerilog(Log.Logger);

}
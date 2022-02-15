using Demo.App.Plugin;
using Demo.Domain.Plugin;
using Demo.Infra.Plugin;
using Demo.WebApi.Plugin;
using NetFusion.Bootstrap.Container;
using NetFusion.Builder;
using NetFusion.Serilog;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Diagnostics;
using NetFusion.Web.Mvc.Extensions;


// Allows changing the minimum log level of the service at runtime.
LogLevelControl LogLevelControl = new();
LogLevelControl.SetMinimumLevel(LogLevel.Debug);

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration(SetupConfiguration);
builder.Host.ConfigureLogging(SetupLogging);
builder.Host.UseSerilog();

builder.Services.AddCors();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

// Register Log Level Control so it can be injected into
// a service at runtime to change the level.
builder.Services.AddLogLevelControl(LogLevelControl);

// Add Plugins to the Composite-Container:
builder.Services.CompositeContainer(builder.Configuration, new SerilogExtendedLogger())
    .AddPlugin<InfraPlugin>()
    .AddPlugin<AppPlugin>()
    .AddPlugin<DomainPlugin>()
    .AddPlugin<WebApiPlugin>()
    .Compose();

var app = builder.Build();

string viewerUrl = app.Configuration.GetValue<string>("Netfusion:ViewerUrl");
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

app.MapHealthCheck();
app.MapStartupCheck();
app.MapReadinessCheck();
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


void SetupConfiguration(HostBuilderContext context, IConfigurationBuilder configBuilder)
{

}


void SetupLogging(HostBuilderContext context,
            ILoggingBuilder logBuilder)
{
    var seqUrl = context.Configuration.GetValue<string>("logging:seqUrl");

    // Send any Serilog configuration issues logs to console.
    Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
    Serilog.Debugging.SelfLog.Enable(Console.Error);

    var logConfig = new LoggerConfiguration()
        .MinimumLevel.ControlledBy(LogLevelControl.Switch)
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

    logBuilder.ClearProviders();
    logBuilder.AddSerilog(Log.Logger);
}
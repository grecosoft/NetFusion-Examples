using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetFusion.Bootstrap.Container;
using NetFusion.Builder;
using NetFusion.Serilog;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using Subscriber.Plugin;

InitializeLogger();

IHost host = null;
try
{
    host = new HostBuilder()
        .ConfigureServices((hostContext, services) =>
        {
            services.CompositeContainer(hostContext.Configuration, new SerilogExtendedLogger())
                .AddPlugin<HostPlugin>()
                .Compose();
        })
        .ConfigureAppConfiguration((context, builder) =>
        {
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json", false);
        })
        .ConfigureLogging(SetupLogging)
        .Build();
}
catch
{
    Log.CloseAndFlush();
}

if (host == null)
{
    return;
}

var compositeApp = host.Services.GetRequiredService<ICompositeApp>();
var lifetime = host.Services.GetRequiredService<IHostApplicationLifetime>();

lifetime.ApplicationStopping.Register(() =>
{
    compositeApp.Stop();
});

await compositeApp.StartAsync();
await host.RunAsync();

void SetupLogging(HostBuilderContext context,
    ILoggingBuilder logBuilder)
{
    logBuilder.ClearProviders();
    logBuilder.AddSerilog(Log.Logger);
}

void InitializeLogger()
{
    const string seqUrl = "http://localhost:5351";

    // Send any Serilog configuration issues logs to console.
    Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
    Serilog.Debugging.SelfLog.Enable(Console.Error);

    var logConfig = new LoggerConfiguration()
        .MinimumLevel.Information()
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
        .Enrich.FromLogContext();
    
    logConfig.WriteTo.Console(theme: AnsiConsoleTheme.Literate);

    if (!string.IsNullOrEmpty(seqUrl))
    {
        logConfig.WriteTo.Seq(seqUrl);
    }

    Log.Logger = logConfig.CreateLogger();
    
}

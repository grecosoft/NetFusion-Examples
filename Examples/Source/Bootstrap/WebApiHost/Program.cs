using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetFusion.Bootstrap.Container;
using NetFusion.Serilog;
using Serilog;
using Serilog.Events;
using WebApiHost.Plugin;

namespace WebApiHost
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IHost webHost = BuildWebHost(args);
            
            var compositeApp = webHost.Services.GetRequiredService<ICompositeApp>();
            var lifetime = webHost.Services.GetRequiredService<IHostApplicationLifetime>();

            lifetime.ApplicationStopping.Register(() =>
            {
                compositeApp.Stop();
                Log.CloseAndFlush();
            });
                  
            await compositeApp.StartAsync();
            await webHost.RunAsync();    
        }

        private static IHost BuildWebHost(string[] args) 
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration)
                .ConfigureLogging(SetupLogging)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog()
                .Build();
        }

        private static void SetupConfiguration(HostBuilderContext context, 
            IConfigurationBuilder builder)
        {
            
        }
        
        private static void SetupLogging(HostBuilderContext context, 
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

            logConfig.WriteTo.ColoredConsole();

            if (! string.IsNullOrEmpty(seqUrl))
            {
                logConfig.WriteTo.Seq(seqUrl);
            }
            
            Log.Logger = logConfig.CreateLogger();
        }
    }
}

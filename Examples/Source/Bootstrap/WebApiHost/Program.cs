using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetFusion.Bootstrap.Container;

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
                .Build();
        }

        private static void SetupConfiguration(HostBuilderContext context, 
            IConfigurationBuilder builder)
        {
            
        }
        
        private static void SetupLogging(HostBuilderContext context, 
            ILoggingBuilder builder)
        {
            
        }
    }
}

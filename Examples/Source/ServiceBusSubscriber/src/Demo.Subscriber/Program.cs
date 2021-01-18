﻿using System.IO;
using System.Threading.Tasks;
using Demo.Subscriber.Plugin;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetFusion.Azure.ServiceBus.Plugin;
using NetFusion.Bootstrap.Container;
using NetFusion.Builder;

namespace Demo.Subscriber
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            IHost host = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.CompositeContainer(hostContext.Configuration)
                        .AddAzureServiceBus()
                        .AddPlugin<HostPlugin>()
                        .Compose();
                })
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                    builder.AddJsonFile("appsettings.json", false);
                })
                .ConfigureLogging((context, builder) =>
                {
                    builder.AddConsole().SetMinimumLevel(LogLevel.Debug);
                })
                .Build();
            
            var compositeApp = host.Services.GetRequiredService<ICompositeApp>();
            var lifetime = host.Services.GetRequiredService<IHostApplicationLifetime>();
            
            lifetime.ApplicationStopping.Register(() =>
            {
                compositeApp.Stop();
            });
            
            await compositeApp.StartAsync();
            await host.RunAsync();
        }
    }
}

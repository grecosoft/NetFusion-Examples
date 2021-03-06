using System;
using System.Threading.Tasks;
using App.Component.Plugin.Configs;
using Core.Component;
using Core.Component.Plugin;
using Microsoft.Extensions.DependencyInjection;
using NetFusion.Bootstrap.Plugins;

namespace App.Component.Plugin.Modules
{
    public class AppModuleOne : PluginModule
    {
        public ICheckValidRange ValidRanges { get; private set; }
        
        public override void Initialize()
        {
            Console.WriteLine($"Initializing: {GetType().Name}");
            var config = Context.Plugin.GetConfig<HelloWorldConfig>();

            if (! string.IsNullOrEmpty(config.Message))
            {
                Console.WriteLine(
                    $"The host application with the name of: {Context.AppHost.Name} says Hello {config.Message}");
            }
        }

        public override void Configure()
        {
            Console.WriteLine($"Configuring: {GetType().Name}");
            
            var range = ValidRanges.IsValidRange(102);
            if (range != null)
            {
                Console.WriteLine($"102 is value range[{range.Item1}, {range.Item2}]");
            }
        }

        public override void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IValidNumbers, ValidNumberComponent>();
        }
        
        protected override Task OnStartModuleAsync(IServiceProvider services)
        {
            Console.WriteLine($"Starting: {GetType().Name}");
            return base.OnStartModuleAsync(services);
        }

        protected override Task OnRunModuleAsync(IServiceProvider services)
        {
            Console.WriteLine($"Running: {GetType().Name}");
            return base.OnRunModuleAsync(services);
        }

        protected override Task OnStopModuleAsync(IServiceProvider services)
        {
            Console.WriteLine($"Stopping: {GetType().Name}");
            return base.OnStopModuleAsync(services);
        }
    }
}

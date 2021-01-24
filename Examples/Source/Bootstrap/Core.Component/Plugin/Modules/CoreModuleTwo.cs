using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NetFusion.Bootstrap.Plugins;

namespace Core.Component.Plugin.Modules
{
    public class CoreModuleTwo : PluginModule
    {
        public ICheckValidRange ValidRanges { get; private set; }
        
        public override void Initialize()
        {
            Console.WriteLine($"Initializing: {GetType().Name}");
        }

        public override void Configure()
        {
            Console.WriteLine($"Configuring: {GetType().Name}");

            var range = ValidRanges.IsValidRange(24);
            if (range != null)
            {
                Console.WriteLine($"24 is value range[{range.Item1}, {range.Item2}]");
            }
        }

        public override void RegisterDefaultServices(IServiceCollection services)
        {
            services.AddSingleton<IValidNumbers, DefaultValidNumberComponent>();
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
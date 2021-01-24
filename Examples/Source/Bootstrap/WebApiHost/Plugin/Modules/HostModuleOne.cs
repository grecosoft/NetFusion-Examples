using System;
using System.Threading.Tasks;
using NetFusion.Bootstrap.Plugins;

namespace WebApiHost.Plugin.Modules
{
    public class HostModuleOne : PluginModule
    {
        public override void Initialize()
        {
            Console.WriteLine($"Initializing: {GetType().Name}");
        }

        public override void Configure()
        {
            Console.WriteLine($"Configuring: {GetType().Name}");
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
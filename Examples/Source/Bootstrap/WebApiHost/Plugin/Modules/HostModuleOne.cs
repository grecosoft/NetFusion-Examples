using NetFusion.Base;
using NetFusion.Bootstrap.Plugins;

namespace WebApiHost.Plugin.Modules
{
    public class HostModuleOne : PluginModule
    {
        public override void Initialize()
        {
            NfExtensions.Logger.Log<PluginModule>(
                LogLevel.Information, $"Initializing: {GetType().Name}");
        }

        public override void Configure()
        {
            NfExtensions.Logger.Log<PluginModule>(
               LogLevel.Information, $"Configuring: {GetType().Name}");
        }

        protected override Task OnStartModuleAsync(IServiceProvider services)
        {
            NfExtensions.Logger.Log<PluginModule>(
                    LogLevel.Warning, $"Starting: {GetType().Name}");

            return base.OnStartModuleAsync(services);
        }

        protected override Task OnRunModuleAsync(IServiceProvider services)
        {
            NfExtensions.Logger.Log<PluginModule>(
                    LogLevel.Warning, $"Running: {GetType().Name}");

            return base.OnRunModuleAsync(services);
        }

        protected override Task OnStopModuleAsync(IServiceProvider services)
        {
            NfExtensions.Logger.Log<PluginModule>(
                    LogLevel.Warning, $"Stopping: {GetType().Name}");

            return base.OnStopModuleAsync(services);
        }
    }
}

using App.Component.Plugin.Configs;
using Core.Component;
using Core.Component.Plugin;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetFusion.Base;
using NetFusion.Bootstrap.Plugins;

namespace App.Component.Plugin.Modules
{
    public class AppModuleOne : PluginModule
    {
        public ICheckValidRange? ValidRanges { get; private set; } 

        public override void Initialize()
        {
            NfExtensions.Logger.Log<PluginModule>(
                LogLevel.Information, $"Initializing: {GetType().Name}");

            var config = Context.Plugin.GetConfig<HelloWorldConfig>();

            if (!string.IsNullOrEmpty(config.Message))
            {
                NfExtensions.Logger.Log<AppModuleOne>(LogLevel.Warning,
                  $"The host application with the name of: {Context.AppHost.Name} says Hello {config.Message}");
            }
        }

        public override void Configure()
        {
            if (ValidRanges == null)
            {
                throw new ArgumentNullException(nameof(ValidRanges));
            }

            NfExtensions.Logger.Log<PluginModule>(
               LogLevel.Information, $"Configuring: {GetType().Name}");

            var range = ValidRanges.IsValidRange(102);
            if (range != null)
            {
                NfExtensions.Logger.Log<AppModuleOne>(
                    LogLevel.Warning, $"102 is value range[{range.Item1}, {range.Item2}]");
            }
        }

        public override void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IValidNumbers, ValidNumberComponent>();
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

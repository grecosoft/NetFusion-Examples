using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetFusion.Base;
using NetFusion.Bootstrap.Plugins;

namespace Core.Component.Plugin.Modules
{
    public class CoreModuleTwo : PluginModule
    {
        public ICheckValidRange? ValidRanges { get; private set; }

        public override void Initialize()
        {
            NfExtensions.Logger.Log<PluginModule>(
                LogLevel.Information, $"Initializing: {GetType().Name}");
        }

        public override void Configure()
        {
            if (ValidRanges == null)
            {
                throw new ArgumentNullException(nameof(ValidRanges));
            }

            NfExtensions.Logger.Log<PluginModule>(
               LogLevel.Information, $"Configuring: {GetType().Name}");

            var range = ValidRanges.IsValidRange(24);
            if (range != null)
            {
                NfExtensions.Logger.Log<CoreModuleTwo>(
                     LogLevel.Warning, $"24 is value range[{range.Item1}, {range.Item2}]");
            }
        }

        public override void RegisterDefaultServices(IServiceCollection services)
        {
            services.AddSingleton<IValidNumbers, DefaultValidNumberComponent>();
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

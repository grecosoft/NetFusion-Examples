using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetFusion.Common.Base;
using NetFusion.Common.Extensions.Reflection;
using NetFusion.Core.Bootstrap.Catalog;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Bootstrapping.CrossCut.Plugin.Modules;

public class CoreModuleTwo : PluginModule
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

    public override void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IValidNumbers, DefaultValidNumberComponent>();
        services.AddSingleton<GeneratorService>();
    }
    
    public override void ScanForServices(ITypeCatalog catalog)
    {
        catalog.AsService<INumberGenerator>(
            t => t.IsConcreteTypeDerivedFrom<INumberGenerator>(),
            ServiceLifetime.Singleton);
    }
}
using Microsoft.Extensions.DependencyInjection;
using NetFusion.Bootstrap.Catalog;
using NetFusion.Bootstrap.Plugins;
using NetFusion.Common.Extensions.Reflection;

namespace Core.Component.Plugin.Modules
{
    public class NumberGeneratorModule : PluginModule
    {
        public override void ScanForServices(ITypeCatalog catalog)
        {
            catalog.AsService<INumberGenerator>(
                t => t.IsConcreteTypeDerivedFrom<INumberGenerator>(),
                ServiceLifetime.Singleton);

        }
    }
}

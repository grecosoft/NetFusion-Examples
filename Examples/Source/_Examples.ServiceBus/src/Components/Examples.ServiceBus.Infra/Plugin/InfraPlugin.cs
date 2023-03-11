using NetFusion.Core.Bootstrap.Plugins;
using Examples.ServiceBus.Infra.Plugin.Modules;

namespace Examples.ServiceBus.Infra.Plugin;

public class InfraPlugin : PluginBase
{
    public override string PluginId => "9AD7D48D-C69F-4FFB-A939-B654DFCB7E4C";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Infrastructure Application Component";

    public InfraPlugin() {
        AddModule<RepositoryModule>();

        Description = "Plugin component containing the application infrastructure.";
    }
}
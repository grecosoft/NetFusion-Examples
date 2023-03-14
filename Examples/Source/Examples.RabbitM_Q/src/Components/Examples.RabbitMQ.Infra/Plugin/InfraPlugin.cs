using NetFusion.Core.Bootstrap.Plugins;
using Examples.RabbitMQ.Infra.Plugin.Modules;

namespace Examples.RabbitMQ.Infra.Plugin;

public class InfraPlugin : PluginBase
{
    public override string PluginId => "5D4D6596-0F6A-4CF8-9CBA-96E0A9F53750";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Infrastructure Application Component";

    public InfraPlugin() {
        AddModule<RepositoryModule>();

        Description = "Plugin component containing the application infrastructure.";
    }
}
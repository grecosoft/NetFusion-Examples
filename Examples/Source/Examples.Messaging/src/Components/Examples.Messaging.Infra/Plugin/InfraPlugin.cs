using NetFusion.Core.Bootstrap.Plugins;
using Examples.Messaging.Infra.Plugin.Modules;

namespace Examples.Messaging.Infra.Plugin;

public class InfraPlugin : PluginBase
{
    public override string PluginId => "6D4DA473-2331-48CE-A49F-328D9F2CF852";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Infrastructure Application Component";

    public InfraPlugin() {
        AddModule<RepositoryModule>();
        AddModule<AdapterModule>();

        Description = "Plugin component containing the application infrastructure.";
    }
}
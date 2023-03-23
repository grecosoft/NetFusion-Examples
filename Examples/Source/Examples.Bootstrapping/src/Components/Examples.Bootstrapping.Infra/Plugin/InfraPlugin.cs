using NetFusion.Core.Bootstrap.Plugins;
using Examples.Bootstrapping.Infra.Plugin.Modules;

namespace Examples.Bootstrapping.Infra.Plugin;

public class InfraPlugin : PluginBase
{
    public override string PluginId => "FB9BF711-7A2E-4B04-9851-DA06A83175FD";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Infrastructure Application Component";

    public InfraPlugin() {
        AddModule<RepositoryModule>();

        Description = "Plugin component containing the application infrastructure.";
    }
}
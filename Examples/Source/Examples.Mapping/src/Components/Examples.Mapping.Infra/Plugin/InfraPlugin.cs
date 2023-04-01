using NetFusion.Core.Bootstrap.Plugins;
using Examples.Mapping.Infra.Plugin.Modules;

namespace Examples.Mapping.Infra.Plugin;

public class InfraPlugin : PluginBase
{
    public override string PluginId => "9C7646AE-D167-4416-A9A3-92C1C901A557";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Infrastructure Application Component";

    public InfraPlugin() {
        AddModule<RepositoryModule>();

        Description = "Plugin component containing the application infrastructure.";
    }
}
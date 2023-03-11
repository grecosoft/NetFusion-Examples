using NetFusion.Core.Bootstrap.Plugins;
using Solution.Context.Infra.Plugin.Modules;

namespace Examples.ServiceBus.Infra.Plugin;

public class InfraPlugin : PluginBase
{
    public override string PluginId => "A3D464CE-772A-414C-B328-238940C83F26";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Infrastructure Application Component";

    public InfraPlugin() {
        AddModule<RepositoryModule>();

        Description = "Plugin component containing the application infrastructure.";
    }
}
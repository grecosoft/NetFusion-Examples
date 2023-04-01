using NetFusion.Core.Bootstrap.Plugins;
using Examples.MongoDB.Infra.Plugin.Modules;

namespace Examples.MongoDB.Infra.Plugin;

public class InfraPlugin : PluginBase
{
    public override string PluginId => "149E3E73-B5CF-4414-B1D1-E9D96A286127";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Infrastructure Application Component";

    public InfraPlugin() {
        AddModule<RepositoryModule>();

        Description = "Plugin component containing the application infrastructure.";
    }
}
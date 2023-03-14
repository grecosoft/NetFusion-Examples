using Examples.Redis.Infra.Plugin.Modules;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Redis.Infra.Plugin;

public class InfraPlugin : PluginBase
{
    public override string PluginId => "88DDBAD0-5DFF-4F85-9D87-BF03880A1427";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Infrastructure Application Component";

    public InfraPlugin() {
        AddModule<RepositoryModule>();

        Description = "Plugin component containing the application infrastructure.";
    }
}
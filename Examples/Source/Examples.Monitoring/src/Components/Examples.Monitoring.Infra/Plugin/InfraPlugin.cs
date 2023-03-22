using Examples.Monitoring.Infra.Plugin.Modules;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Monitoring.Infra.Plugin;

public class InfraPlugin : PluginBase
{
    public override string PluginId => "58761E08-A7C2-4EF5-BA85-0FB57E90FCF7";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Infrastructure Application Component";

    public InfraPlugin() {
        AddModule<RepositoryModule>();
        AddModule<CachedItemsModule>();

        Description = "Plugin component containing the application infrastructure.";
    }
}
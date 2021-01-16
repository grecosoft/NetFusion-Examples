using NetFusion.Bootstrap.Plugins;
using Demo.Infra.Plugin.Modules;

namespace Demo.Infra.Plugin
{
    public class InfraPlugin : PluginBase
    {
        public override string PluginId => "29dcf4db-064a-479b-bac5-a8e5dcced5ac";
        public override PluginTypes PluginType => PluginTypes.ApplicationPlugin;
        public override string Name => "Infrastructure Application Component";

        public InfraPlugin() {
            AddModule<RepositoryModule>();

            Description = "Plugin component containing the application infrastructure.";
        }
    }
}

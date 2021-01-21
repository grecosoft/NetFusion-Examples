using NetFusion.Bootstrap.Plugins;

namespace Core.Component.Plugin
{
    public class InfraPlugin : PluginBase
    {
        public override string PluginId => "29dcf4db-064a-479b-bac5-a8e5dcced5ac";
        public override PluginTypes PluginType => PluginTypes.CorePlugin;
        public override string Name => "Core Component";

        public InfraPlugin() {
            Description = "Plugin component containing non application specific components.";
        }
    }
}
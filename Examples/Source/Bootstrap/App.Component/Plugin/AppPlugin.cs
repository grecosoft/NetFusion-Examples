using NetFusion.Bootstrap.Plugins;

namespace App.Component.Plugin
{
    public class AppPlugin : PluginBase
    {
        public override string PluginId => "9a9ba50a-0347-455c-b2fd-68a82221d2ae";
        public override PluginTypes PluginType => PluginTypes.ApplicationPlugin;
        public override string Name => "Application Services Component";

        public AppPlugin()
        {
            Description = "Example component containing application services.";
        }   
    }
}
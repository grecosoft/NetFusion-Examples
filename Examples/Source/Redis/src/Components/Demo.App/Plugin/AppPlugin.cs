using NetFusion.Bootstrap.Plugins;
using Demo.App.Plugin.Modules;

namespace Demo.App.Plugin
{
    public class AppPlugin : PluginBase
    {
        public override string PluginId => "9a9ba50a-0347-455c-b2fd-68a82221d2ae";
        public override PluginTypes PluginType => PluginTypes.AppPlugin;
        public override string Name => "Application Services Component";

        public AppPlugin()
        {
            AddModule<ServiceModule>();

            Description = "Plugin component containing the Microservice's application services.";
        }   
    }
}
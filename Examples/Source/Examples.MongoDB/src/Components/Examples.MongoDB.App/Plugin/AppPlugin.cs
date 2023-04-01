using NetFusion.Core.Bootstrap.Plugins;
using Examples.MongoDB.App.Plugin.Modules;

namespace Examples.MongoDB.App.Plugin;

public class AppPlugin : PluginBase
{
    public override string PluginId => "91622AE2-8CC5-490E-9DC6-31480AB53676";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Application Services Component";

    public AppPlugin()
    {
        AddModule<ServiceModule>();

        Description = "Plugin component containing the Microservice's application services.";
    }   
}
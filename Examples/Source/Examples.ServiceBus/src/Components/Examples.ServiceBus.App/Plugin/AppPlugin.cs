using Examples.ServiceBus.App.Plugin.Modules;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.ServiceBus.App.Plugin;

public class AppPlugin : PluginBase
{
    public override string PluginId => "1DD1AE8F-5D36-497C-88EF-FE4FBFE2D9E2";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Application Services Component";

    public AppPlugin()
    {
        AddModule<ServiceModule>();

        Description = "Plugin component containing the Microservice's application services.";
    }   
}
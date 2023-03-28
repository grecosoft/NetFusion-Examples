using NetFusion.Core.Bootstrap.Plugins;
using Examples.Messaging.App.Plugin.Modules;

namespace Examples.Messaging.App.Plugin;

public class AppPlugin : PluginBase
{
    public override string PluginId => "9146FE91-897C-4E4A-AC3E-750C3C553ADA";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Application Services Component";

    public AppPlugin()
    {
        AddModule<ServiceModule>();

        Description = "Plugin component containing the Microservice's application services.";
    }   
}
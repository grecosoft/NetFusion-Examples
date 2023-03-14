using Examples.Redis.App.Plugin.Modules;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Redis.App.Plugin;

public class AppPlugin : PluginBase
{
    public override string PluginId => "CBA76948-D619-40EC-A1F0-9BE3A4174701";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Application Services Component";

    public AppPlugin()
    {
        AddModule<ServiceModule>();

        Description = "Plugin component containing the Microservice's application services.";
    }   
}
using Examples.Monitoring.App.Plugin.Modules;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Monitoring.App.Plugin;

public class AppPlugin : PluginBase
{
    public override string PluginId => "58E80E7F-66E8-4F11-A0E5-3DEBD5922EB4";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Application Services Component";

    public AppPlugin()
    {
        AddModule<ServiceModule>();
        AddModule<PendingRequestsModule>(); 

        Description = "Plugin component containing the Microservice's application services.";
    }   
}
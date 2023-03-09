using NetFusion.Core.Bootstrap.Plugins;
using Examples.ServiceBus.App.Plugin.Modules;

namespace Examples.ServiceBus.App.Plugin;

public class AppPlugin : PluginBase
{
    public override string PluginId => "AF96498A-4BBA-491E-9B21-9EF654DD15FA";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Application Services Component";

    public AppPlugin()
    {
        AddModule<ServiceModule>();

        Description = "Plugin component containing the Microservice's application services.";
    }   
}
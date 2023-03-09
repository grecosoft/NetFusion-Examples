using NetFusion.Core.Bootstrap.Plugins;
using Examples.RabbitMq.App.Plugin.Modules;

namespace Examples.RabbitMq.App.Plugin;

public class AppPlugin : PluginBase
{
    public override string PluginId => "85D4DDDF-5C3A-4710-A066-F66353D18B4E";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Application Services Component";

    public AppPlugin()
    {
        AddModule<ServiceModule>();

        Description = "Plugin component containing the Microservice's application services.";
    }   
}
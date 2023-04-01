using NetFusion.Core.Bootstrap.Plugins;
using Examples.Mapping.App.Plugin.Modules;

namespace Examples.Mapping.App.Plugin;

public class AppPlugin : PluginBase
{
    public override string PluginId => "6330F311-D5FB-40BE-9E55-DB7015071848";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Application Services Component";

    public AppPlugin()
    {
        AddModule<ServiceModule>();

        Description = "Plugin component containing the Microservice's application services.";
    }   
}
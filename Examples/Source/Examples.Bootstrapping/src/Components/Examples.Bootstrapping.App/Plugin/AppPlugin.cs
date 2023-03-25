using Examples.Bootstrapping.App.Plugin.Configs;
using NetFusion.Core.Bootstrap.Plugins;
using Examples.Bootstrapping.App.Plugin.Modules;

namespace Examples.Bootstrapping.App.Plugin;

public class AppPlugin : PluginBase
{
    public override string PluginId => "FA2A1F82-471C-44D0-A56C-01A7163D71C2";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Application Services Component";

    public AppPlugin()
    {
        AddConfig<HelloWorldConfig>();
        
        AddModule<ServiceModule>();
        AddModule<AppModuleOne>();

        Description = "Plugin component containing the Microservice's application services.";
    }   
}
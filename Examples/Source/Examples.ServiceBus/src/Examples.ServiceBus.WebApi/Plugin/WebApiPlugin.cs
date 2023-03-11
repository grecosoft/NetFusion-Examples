using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.ServiceBus.WebApi.Plugin;

public class WebApiPlugin : PluginBase
{
    public const string HostId = "9A06D394-8F82-4D13-B42E-A4D9972F44E7";
    public const string HostName = "ExampleWebApiHost";

    public override PluginTypes PluginType => PluginTypes.HostPlugin;
    public override string PluginId => HostId;
    public override string Name => HostName;
        
    public WebApiPlugin()
    {
        Description = "WebApi host exposing REST based Web API.";
    }
}
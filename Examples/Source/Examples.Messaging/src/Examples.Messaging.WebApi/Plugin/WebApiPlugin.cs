using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Messaging.WebApi.Plugin;

public class WebApiPlugin : PluginBase
{
    public const string HostId = "1B0BC086-EBBA-42BE-B168-695060F8303A";
    public const string HostName = "examples-messaging";

    public override PluginTypes PluginType => PluginTypes.HostPlugin;
    public override string PluginId => HostId;
    public override string Name => HostName;
        
    public WebApiPlugin()
    {
        Description = "WebApi host exposing REST/HAL based Web API.";
    }
}
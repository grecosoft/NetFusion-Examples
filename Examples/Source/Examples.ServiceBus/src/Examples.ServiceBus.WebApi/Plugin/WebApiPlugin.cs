using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.ServiceBus.WebApi.Plugin;

public class WebApiPlugin : PluginBase
{
    public const string HostId = "5AE08967-B50C-4D38-9937-C6882CECE0AE";
    public const string HostName = "examples-servicebus";

    public override PluginTypes PluginType => PluginTypes.HostPlugin;
    public override string PluginId => HostId;
    public override string Name => HostName;
        
    public WebApiPlugin()
    {
        Description = "WebApi host exposing REST/HAL based Web API.";
    }
}
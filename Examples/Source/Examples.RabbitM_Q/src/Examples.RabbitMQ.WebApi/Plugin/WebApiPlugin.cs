using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.RabbitMQ.WebApi.Plugin;

public class WebApiPlugin : PluginBase
{
    public const string HostId = "FE9F2BC7-900E-4DC3-928E-5EEB03EA05BC";
    public const string HostName = "examples-rabbitmq";

    public override PluginTypes PluginType => PluginTypes.HostPlugin;
    public override string PluginId => HostId;
    public override string Name => HostName;
        
    public WebApiPlugin()
    {
        Description = "WebApi host exposing REST/HAL based Web API.";
    }
}
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Monitoring.WebApi.Plugin;

public class WebApiPlugin : PluginBase
{
    public const string HostId = "688FE108-8A2A-4A37-A06B-30AE8049325D";
    public const string HostName = "ExampleWebApiHost";

    public override PluginTypes PluginType => PluginTypes.HostPlugin;
    public override string PluginId => HostId;
    public override string Name => HostName;
        
    public WebApiPlugin()
    {
        Description = "WebApi host exposing REST based Web API.";
    }
}
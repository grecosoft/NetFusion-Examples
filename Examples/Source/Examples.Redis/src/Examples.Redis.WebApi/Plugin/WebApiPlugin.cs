using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Redis.WebApi.Plugin;

public class WebApiPlugin : PluginBase
{
    public const string HostId = "B83D148E-D230-48CB-8E18-A43323F2F6F0";
    public const string HostName = "ExampleWebApiHost";

    public override PluginTypes PluginType => PluginTypes.HostPlugin;
    public override string PluginId => HostId;
    public override string Name => HostName;
        
    public WebApiPlugin()
    {
        Description = "WebApi host exposing REST based Web API.";
    }
}
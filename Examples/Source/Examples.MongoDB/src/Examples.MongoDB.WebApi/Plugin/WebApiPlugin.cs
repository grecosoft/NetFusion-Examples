using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.MongoDB.WebApi.Plugin;

public class WebApiPlugin : PluginBase
{
    public const string HostId = "2F442905-B805-4492-9272-806E2EE269E3";
    public const string HostName = "examples-mongodb";

    public override PluginTypes PluginType => PluginTypes.HostPlugin;
    public override string PluginId => HostId;
    public override string Name => HostName;
        
    public WebApiPlugin()
    {
        Description = "WebApi host exposing REST/HAL based Web API.";
    }
}
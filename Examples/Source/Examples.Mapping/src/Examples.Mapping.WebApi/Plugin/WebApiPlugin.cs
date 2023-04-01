using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Mapping.WebApi.Plugin;

public class WebApiPlugin : PluginBase
{
    public const string HostId = "609C5A93-9DC8-423E-9D10-AD1CDA2CE350";
    public const string HostName = "examples-mapping";

    public override PluginTypes PluginType => PluginTypes.HostPlugin;
    public override string PluginId => HostId;
    public override string Name => HostName;
        
    public WebApiPlugin()
    {
        Description = "WebApi host exposing REST/HAL based Web API.";
    }
}
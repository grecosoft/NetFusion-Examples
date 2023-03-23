using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Bootstrapping.WebApi.Plugin;

public class WebApiPlugin : PluginBase
{
    public const string HostId = "F30D55C9-D06D-481F-860F-8E9524BC73B8";
    public const string HostName = "examples-bootstrapping";

    public override PluginTypes PluginType => PluginTypes.HostPlugin;
    public override string PluginId => HostId;
    public override string Name => HostName;
        
    public WebApiPlugin()
    {
        Description = "WebApi host exposing REST/HAL based Web API.";
    }
}
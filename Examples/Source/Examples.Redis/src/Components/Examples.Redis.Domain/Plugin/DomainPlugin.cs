using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Redis.Domain.Plugin;

public class DomainPlugin : PluginBase
{
    public override string PluginId => "4D7DEDAE-6FCC-474D-B4D3-2D3A48DBE5B0";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Domain Model Component";
        
    public DomainPlugin()
    {
        Description = "Plugin component containing the Microservice's domain model.";
    }
}
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.MongoDB.Domain.Plugin;

public class DomainPlugin : PluginBase
{
    public override string PluginId => "D8557FC2-C5D3-426F-B3E7-B78A4D33BB66";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Domain Model Component";
        
    public DomainPlugin()
    {
        Description = "Plugin component containing the Microservice's domain model.";
    }
}
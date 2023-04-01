using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Mapping.Domain.Plugin;

public class DomainPlugin : PluginBase
{
    public override string PluginId => "B0AF817F-79AD-4056-966A-DFF0F8F06478";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Domain Model Component";
        
    public DomainPlugin()
    {
        Description = "Plugin component containing the Microservice's domain model.";
    }
}
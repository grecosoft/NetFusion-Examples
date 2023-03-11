using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.ServiceBus.Domain.Plugin;

public class DomainPlugin : PluginBase
{
    public override string PluginId => "E7F64E27-77C7-40FC-92B5-954E4DF5D87C";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Domain Model Component";
        
    public DomainPlugin()
    {
        Description = "Plugin component containing the Microservice's domain model.";
    }
}
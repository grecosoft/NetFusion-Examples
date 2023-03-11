using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.ServiceBus.Domain.Plugin;

public class DomainPlugin : PluginBase
{
    public override string PluginId => "BFD2229A-2758-4E65-966A-33EA12423DB9";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Domain Model Component";
        
    public DomainPlugin()
    {
        Description = "Plugin component containing the Microservice's domain model.";
    }
}
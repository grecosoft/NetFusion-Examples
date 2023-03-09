using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.RabbitMq.Domain.Plugin;

public class DomainPlugin : PluginBase
{
    public override string PluginId => "CCEBE9EA-02A4-4D75-AE23-8CD033606AB1";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Domain Model Component";
        
    public DomainPlugin()
    {
        Description = "Plugin component containing the Microservice's domain model.";
    }
}
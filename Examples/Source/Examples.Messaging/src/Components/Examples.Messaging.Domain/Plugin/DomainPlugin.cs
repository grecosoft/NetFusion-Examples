using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Messaging.Domain.Plugin;

public class DomainPlugin : PluginBase
{
    public override string PluginId => "BE19E1C6-DB2E-4A73-A8F8-8ED841C6F887";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Domain Model Component";
        
    public DomainPlugin()
    {
        Description = "Plugin component containing the Microservice's domain model.";
    }
}
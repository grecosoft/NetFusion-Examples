using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Bootstrapping.Domain.Plugin;

public class DomainPlugin : PluginBase
{
    public override string PluginId => "C2236E9D-424D-4372-ABB1-F3B112612E3C";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Domain Model Component";
        
    public DomainPlugin()
    {
        Description = "Plugin component containing the Microservice's domain model.";
    }
}
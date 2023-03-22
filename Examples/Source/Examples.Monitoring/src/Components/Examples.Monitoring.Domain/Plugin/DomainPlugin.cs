using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Monitoring.Domain.Plugin;

public class DomainPlugin : PluginBase
{
    public override string PluginId => "4CF9BDF4-92B7-4ABD-9618-D5BDCB8B963A";
    public override PluginTypes PluginType => PluginTypes.AppPlugin;
    public override string Name => "Domain Model Component";
        
    public DomainPlugin()
    {
        Description = "Plugin component containing the Microservice's domain model.";
    }
}
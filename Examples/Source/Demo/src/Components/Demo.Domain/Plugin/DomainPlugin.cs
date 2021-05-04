using NetFusion.Bootstrap.Plugins;

namespace Demo.Domain.Plugin
{
    public class DomainPlugin : PluginBase
    {
        public override string PluginId => "bc1f874c-452c-4df4-93a6-d6b5924e5bd6";
        public override PluginTypes PluginType => PluginTypes.AppPlugin;
        public override string Name => "Domain Model Component";
        
        public DomainPlugin()
        {
            Description = "Plugin component containing the Microservice's domain model.";
        }
    }
}
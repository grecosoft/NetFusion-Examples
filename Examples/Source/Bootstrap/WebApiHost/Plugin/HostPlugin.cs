using NetFusion.Bootstrap.Plugins;

namespace WebApiHost.Plugin
{
    public class WebApiPlugin : PluginBase
    {
        public const string HostId = "a20e628c-fb31-4566-a43c-c2548f0a3329";
        public const string HostName = "Web Host";

        public override PluginTypes PluginType => PluginTypes.HostPlugin;
        public override string PluginId => HostId;
        public override string Name => HostName;
        
        public WebApiPlugin()
        {
            Description = "Example WebApi Host";
            
            AddModule<HostModuleOne>();
        }
    }
}

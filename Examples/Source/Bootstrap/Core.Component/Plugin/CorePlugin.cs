using Core.Component.Plugin.Modules;
using NetFusion.Bootstrap.Plugins;

namespace Core.Component.Plugin
{
    public class CorePlugin : PluginBase
    {
        public override string PluginId => "29dcf4db-064a-479b-bac5-a8e5dcced5ac";
        public override PluginTypes PluginType => PluginTypes.CorePlugin;
        public override string Name => "Core Component";

        public CorePlugin() 
        {
            Description = "Plugin component containing non application specific components.";
            
            AddModule<CoreModuleOne>();
            AddModule<CoreModuleTwo>();
            AddModule<ValidAddressModule>();
            AddModule<NumberGeneratorModule>();
        }
    }
}
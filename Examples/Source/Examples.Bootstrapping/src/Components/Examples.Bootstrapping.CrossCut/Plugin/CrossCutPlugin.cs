using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Bootstrapping.CrossCut.Plugin;

public class CrossCutPlugin : PluginBase
{
    public override string PluginId => "7332C55B-E64C-430C-8836-488787CAC875";
    public override PluginTypes PluginType => PluginTypes.CorePlugin;
    public override string Name => "Cross-Cut Component";

    public CrossCutPlugin()
    {
        Description = "Example of a core plugin";
    }   
}
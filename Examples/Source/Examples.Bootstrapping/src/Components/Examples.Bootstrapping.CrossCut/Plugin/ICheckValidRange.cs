using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Bootstrapping.CrossCut.Plugin;

public interface ICheckValidRange : IPluginModuleService
{
    Tuple<int, int>? IsValidRange(int value);
}
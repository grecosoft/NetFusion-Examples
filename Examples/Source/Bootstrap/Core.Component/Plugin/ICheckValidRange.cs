using System;
using NetFusion.Bootstrap.Plugins;

namespace Core.Component.Plugin
{
    public interface ICheckValidRange : IPluginModuleService
    {
        Tuple<int, int> IsValidRange(int value);
    }
}

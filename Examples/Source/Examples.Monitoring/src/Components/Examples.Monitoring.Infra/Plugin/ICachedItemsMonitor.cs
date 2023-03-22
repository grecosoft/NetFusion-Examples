using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Monitoring.Infra.Plugin;

public interface ICachedItemsMonitor : IPluginModuleService
{
    void SetCachedItems(int numberPending);
}
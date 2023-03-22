using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Monitoring.App.Plugin;

public interface IPendingRequestsMonitor : IPluginModuleService
{
    void SetPendingRequests(int numberPending);
}
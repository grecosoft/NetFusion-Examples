using NetFusion.Bootstrap.Plugins;

namespace Demo.App.Services;

public interface IRunningServicesMonitor : IPluginModuleService
{
    void AddRunningService(string serviceId);
    string RemoveRunningService();
}
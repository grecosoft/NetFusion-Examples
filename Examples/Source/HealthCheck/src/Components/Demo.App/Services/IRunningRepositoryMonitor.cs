using NetFusion.Bootstrap.Plugins;

namespace Demo.App.Services;

public interface IRunningRepositoryMonitor : IPluginModuleService
{
    void AddRunningRepo(string repositoryId);
    string RemoveRunningRepo();
}
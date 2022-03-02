using System.Collections.Concurrent;
using System.Threading.Tasks;
using Demo.App.Services;
using Microsoft.Extensions.DependencyInjection;
using NetFusion.Bootstrap.Catalog;
using NetFusion.Bootstrap.Health;
using NetFusion.Bootstrap.Plugins;

namespace Demo.Infra.Plugin.Modules
{
    public class RepositoryModule : PluginModule,
        IRunningRepositoryMonitor,
        IModuleHealthCheck
    {
        private readonly ConcurrentStack<string> _runningRepositories = new();
        
        public override void ScanForServices(ITypeCatalog catalog)
        {
            catalog.AsImplementedInterface("Repository", ServiceLifetime.Scoped);
        }

        public Task CheckModuleAspectsAsync(ModuleHealthCheck healthCheck)
        {
            HealthAspectCheck aspect = _runningRepositories.Count switch
            {
                <= 2 => HealthAspectCheck.ForHealthy("Running-Repos", _runningRepositories.Count.ToString()),
                <= 4 => HealthAspectCheck.ForDegraded("Running-Repos", _runningRepositories.Count.ToString()),
                > 4 => HealthAspectCheck.ForUnhealthy("Running-Repos", _runningRepositories.Count.ToString())
            };

            if (aspect != null)
            {
                healthCheck.RecordAspect(aspect);
            }

            return Task.CompletedTask;
        }
        
        public void AddRunningRepo(string repositoryId)
        {
            _runningRepositories.Push(repositoryId);
        }

        public string RemoveRunningRepo()
        {
            return _runningRepositories.TryPop(out var serviceId) ? serviceId : null;
        }
    }
}
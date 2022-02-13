using System.Collections.Concurrent;
using System.Threading.Tasks;
using Demo.App.Services;
using Microsoft.Extensions.DependencyInjection;
using NetFusion.Bootstrap.Catalog;
using NetFusion.Bootstrap.Health;
using NetFusion.Bootstrap.Plugins;

namespace Demo.App.Plugin.Modules
{
    public class ServiceModule : PluginModule,
        IRunningServicesMonitor,
        IModuleHealthCheck
    {
        private readonly ConcurrentStack<string> _runningServices = new();

        public override void ScanForServices(ITypeCatalog catalog)
        {
            catalog.AsImplementedInterface("Service", ServiceLifetime.Scoped);
        }

        public Task CheckModuleAspectsAsync(ModuleHealthCheck healthCheck)
        {
            switch (_runningServices.Count)
            {
                case <= 4:
                    healthCheck.RecordAspect(HealthAspectCheck.ForHealthy("RunningServices",
                        _runningServices.Count.ToString()));
                    break;
                case <= 8:
                    healthCheck.RecordAspect(HealthAspectCheck.ForDegraded("RunningServices",
                        _runningServices.Count.ToString()));
                    break;
                case > 8:
                    healthCheck.RecordAspect(HealthAspectCheck.ForUnhealthy("RunningServices",
                        _runningServices.Count.ToString()));
                    break;
            }

            return Task.CompletedTask;
        }

        public void AddRunningService(string serviceId)
        {
            _runningServices.Push(serviceId);
        }

        public string RemoveRunningService()
        {
            return _runningServices.TryPop(out var serviceId) ? serviceId : null;
        }
    }
}
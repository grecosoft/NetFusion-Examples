using System;
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
            HealthAspectCheck aspect = _runningServices.Count switch
            {
                <= 4 => HealthAspectCheck.ForHealthy("Running-Services", _runningServices.Count.ToString()),
                <= 8 => HealthAspectCheck.ForDegraded("Running-Services", _runningServices.Count.ToString()),
                > 8 => HealthAspectCheck.ForUnhealthy("Running-Services", _runningServices.Count.ToString())
            };

            if (aspect != null)
            {
                healthCheck.RecordAspect(aspect);
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

        protected override Task OnStartModuleAsync(IServiceProvider services)
        {
            return Task.Delay(TimeSpan.FromSeconds(20));
        }
    }
}
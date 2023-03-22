using System.Threading.Tasks;
using NetFusion.Core.Bootstrap.Health;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Monitoring.Infra.Plugin.Modules;

public class CachedItemsModule : PluginModule,
    ICachedItemsMonitor,
    IModuleHealthCheckProvider
{
    private int _numberCached;
    
    public void SetCachedItems(int numberCached)
    {
        _numberCached = numberCached;
    }

    public Task CheckModuleAspectsAsync(ModuleHealthCheck healthCheck)
    {
        HealthAspectCheck aspect = _numberCached switch
        {
            >= 0 and <= 1000 => HealthAspectCheck.ForHealthy("Cached-Items", _numberCached.ToString()),
            > 1000 and <= 2000 => HealthAspectCheck.ForDegraded("Cached-Items", _numberCached.ToString()),
            > 2000 => HealthAspectCheck.ForUnhealthy("Cached-Items", _numberCached.ToString()),
            _ => HealthAspectCheck.ForUnhealthy("Cached-Items", _numberCached.ToString())
        };
        
        healthCheck.RecordAspect(aspect);
        return Task.CompletedTask;
    }
}
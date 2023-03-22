using System.Threading.Tasks;
using NetFusion.Core.Bootstrap.Health;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Monitoring.App.Plugin.Modules;

public class PendingRequestsModule : PluginModule,
    IPendingRequestsMonitor,
    IModuleHealthCheckProvider
{
    private int _numberPending;
    
    public void SetPendingRequests(int numberPending)
    {
        _numberPending = numberPending;
    }

    public Task CheckModuleAspectsAsync(ModuleHealthCheck healthCheck)
    {
        HealthAspectCheck aspect = _numberPending switch
        {
            >= 0 and <= 5 => HealthAspectCheck.ForHealthy("Pending-Requests", _numberPending.ToString()),
            > 5 and <= 50 => HealthAspectCheck.ForDegraded("Pending-Requests", _numberPending.ToString()),
            > 50 => HealthAspectCheck.ForUnhealthy("Pending-Requests", _numberPending.ToString()),
            _ => HealthAspectCheck.ForUnhealthy("Pending-Requests", _numberPending.ToString())
        };
        
        healthCheck.RecordAspect(aspect);
        return Task.CompletedTask;
    }
}
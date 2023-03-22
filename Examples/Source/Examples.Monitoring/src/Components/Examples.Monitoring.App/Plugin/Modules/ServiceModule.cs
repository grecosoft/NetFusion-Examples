using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NetFusion.Core.Bootstrap.Catalog;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Monitoring.App.Plugin.Modules;

public class ServiceModule : PluginModule
{
    public override void ScanForServices(ITypeCatalog catalog)
    {
        catalog.AsImplementedInterface("Service", ServiceLifetime.Scoped);
    }
    
    protected override Task OnStartModuleAsync(IServiceProvider services)
    {
        return Task.Delay(TimeSpan.FromSeconds(20));
    }
}
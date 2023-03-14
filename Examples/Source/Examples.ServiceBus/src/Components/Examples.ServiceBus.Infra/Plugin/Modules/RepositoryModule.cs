using Examples.ServiceBus.App.Services;
using Examples.ServiceBus.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.ServiceBus.Infra.Plugin.Modules;

public class RepositoryModule : PluginModule
{
    public override void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IPendingAutoServiceRepository, PendingAutoServiceRepository>();
    }
}
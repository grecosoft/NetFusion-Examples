using Examples.RabbitMQ.App.Repositories;
using Microsoft.Extensions.DependencyInjection;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.RabbitMq.Infra.Plugin.Modules;

public class RepositoryModule : PluginModule
{
    public override void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IPendingAutoServiceRepository, PendingAutoServiceRepository>();
    }
}
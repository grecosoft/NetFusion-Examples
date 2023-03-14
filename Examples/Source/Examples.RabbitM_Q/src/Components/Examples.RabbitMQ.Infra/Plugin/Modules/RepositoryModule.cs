using Examples.RabbitMQ.App.Repositories;
using Examples.RabbitMQ.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.RabbitMQ.Infra.Plugin.Modules;

public class RepositoryModule : PluginModule
{
    public override void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IPendingAutoServiceRepository, PendingAutoServiceRepository>();
    }
}
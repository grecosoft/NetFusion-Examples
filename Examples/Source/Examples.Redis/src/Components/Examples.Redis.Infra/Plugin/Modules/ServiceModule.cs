using Examples.Redis.App.Services;
using Microsoft.Extensions.DependencyInjection;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Redis.Infra.Plugin.Modules;

public class ServiceModule : PluginModule
{
    public override void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IEventLogSubscriber, EventLogSubscriber>();
    }
}
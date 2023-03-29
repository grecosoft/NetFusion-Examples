using Examples.Messaging.App.Adapters;
using Examples.Messaging.Infra.Adapters;
using Microsoft.Extensions.DependencyInjection;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Messaging.Infra.Plugin.Modules;

public class AdapterModule : PluginModule
{
    public override void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IRegistrationDataAdapter, RegistrationDataAdapter>();
    }
}
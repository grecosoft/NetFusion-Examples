using Examples.Mapping.App.Services;
using Examples.Mapping.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Mapping.App.Plugin.Modules;

public class ServiceModule : PluginModule
{
    public override void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<SampleEntityService>();
        services.AddScoped<IEntityIdGenerator, EntityIdGenerator>();
    }
}
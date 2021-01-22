using App.Component.Plugin;
using App.Component.Plugin.Configs;
using Core.Component.Plugin;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetFusion.Builder;
using NetFusion.Serilog;
using Serilog;
using WebApiHost.Plugin;

namespace WebApiHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.CompositeContainer(Configuration, new SerilogExtendedLogger())
                
                // Register Additional Plugins Here:
                
                .AddPlugin<CorePlugin>()
                .AddPlugin<AppPlugin>()
                .AddPlugin<WebApiPlugin>()
                
                .InitPluginConfig((HelloWorldConfig config) => config.SetMessage("is anyone home?"))
                
                .Compose();
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSerilogRequestLogging();
            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

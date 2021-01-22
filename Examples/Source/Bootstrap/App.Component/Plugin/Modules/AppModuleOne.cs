using System;
using App.Component.Plugin.Configs;
using NetFusion.Bootstrap.Plugins;

namespace App.Component.Plugin.Modules
{
    public class AppModuleOne : PluginModule
    {
        public override void Initialize()
        {
            Console.WriteLine($"Initializing: {GetType().Name}");
            var config = Context.Plugin.GetConfig<HelloWorldConfig>();

            if (! string.IsNullOrEmpty(config.Message))
            {
                Console.WriteLine(
                    $"The host application with the name of: {Context.AppHost.Name} says Hello {config.Message}");
            }
        }

        public override void Configure()
        {
            Console.WriteLine($"Configuring: {GetType().Name}");
        }
    }
}

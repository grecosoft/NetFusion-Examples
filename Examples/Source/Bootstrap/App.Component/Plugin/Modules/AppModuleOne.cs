using System;
using App.Component.Plugin.Configs;
using Core.Component.Plugin;
using NetFusion.Bootstrap.Plugins;

namespace App.Component.Plugin.Modules
{
    public class AppModuleOne : PluginModule
    {
        public ICheckValidRange ValidRanges { get; private set; }
        
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
            
            var range = ValidRanges.IsValidRange(102);
            if (range != null)
            {
                Console.WriteLine($"102 is value range[{range.Item1}, {range.Item2}]");
            }
        }
    }
}

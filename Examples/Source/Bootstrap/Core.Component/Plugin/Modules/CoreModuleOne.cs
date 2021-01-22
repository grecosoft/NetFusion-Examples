using System;
using NetFusion.Bootstrap.Plugins;

namespace Core.Component.Plugin.Modules
{
    public class CoreModuleOne : PluginModule
    {
        public override void Initialize()
        {
            Console.WriteLine($"Initializing: {GetType().Name}");
        }

        public override void Configure()
        {
            Console.WriteLine($"Configuring: {GetType().Name}");
        }
    }
}
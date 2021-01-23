using System;
using NetFusion.Bootstrap.Plugins;

namespace WebApiHost.Plugin
{
    public class HostModuleOne : PluginModule
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
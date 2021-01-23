using System;
using NetFusion.Bootstrap.Plugins;

namespace Core.Component.Plugin.Modules
{
    public class CoreModuleTwo : PluginModule
    {
        public ICheckValidRange ValidRanges { get; private set; }
        
        public override void Initialize()
        {
            Console.WriteLine($"Initializing: {GetType().Name}");
        }

        public override void Configure()
        {
            Console.WriteLine($"Configuring: {GetType().Name}");

            var range = ValidRanges.IsValidRange(24);
            if (range != null)
            {
                Console.WriteLine($"24 is value range[{range.Item1}, {range.Item2}]");
            }
        }
    }
}
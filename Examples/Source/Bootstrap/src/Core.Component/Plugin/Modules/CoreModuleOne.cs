using System;
using System.Collections.Generic;
using System.Linq;
using NetFusion.Bootstrap.Plugins;

namespace Core.Component.Plugin.Modules
{
    public class CoreModuleOne : PluginModule,
        ICheckValidRange
    {
        private readonly List<Tuple<int, int>> _validRanges = new ();

        public override void Initialize()
        {
            _validRanges.Add(Tuple.Create(5, 10));
            _validRanges.Add(Tuple.Create(22, 31));
            _validRanges.Add(Tuple.Create(42, 72));
            _validRanges.Add(Tuple.Create(100, 105));
            
            Console.WriteLine($"Initializing: {GetType().Name}");
        }

        public override void Configure()
        {
            Console.WriteLine($"Configuring: {GetType().Name}");
        }

        public Tuple<int, int> IsValidRange(int value)
        {
            return _validRanges.FirstOrDefault(r => value >= r.Item1 && value <= r.Item2);
        }
    }
}
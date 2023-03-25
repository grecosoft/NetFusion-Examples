using Microsoft.Extensions.Logging;
using NetFusion.Common.Base;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Bootstrapping.CrossCut.Plugin.Modules;

public class CoreModuleOne : PluginModule,
    ICheckValidRange
{
    private readonly List<Tuple<int, int>> _validRanges = new ();
    
    public override void Initialize()
    {
        NfExtensions.Logger.Log<PluginModule>(
            LogLevel.Information, $"Initializing: {GetType().Name}");
        
        _validRanges.Add(Tuple.Create(5, 10));
        _validRanges.Add(Tuple.Create(22, 31));
        _validRanges.Add(Tuple.Create(42, 72));
        _validRanges.Add(Tuple.Create(100, 105));
    }

    public override void Configure()
    {
        NfExtensions.Logger.Log<PluginModule>(
            LogLevel.Information, $"Configuring: {GetType().Name}");
    }
    
    public Tuple<int, int>? IsValidRange(int value)
    {
        return _validRanges.FirstOrDefault(r => value >= r.Item1 && value <= r.Item2);
    }
}
using System;
using Examples.Bootstrapping.App.Plugin.Configs;
using Examples.Bootstrapping.CrossCut.Plugin;
using Microsoft.Extensions.Logging;
using NetFusion.Common.Base;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Bootstrapping.App.Plugin.Modules;

public class AppModuleOne : PluginModule
{
    private ICheckValidRange ValidRanges { get; set; } = null!;
    
    public override void Initialize()
    {
        NfExtensions.Logger.Log<PluginModule>(
            LogLevel.Information, $"Initializing: {GetType().Name}");
        
        NfExtensions.Logger.Log<PluginModule>(
            LogLevel.Information, $"Host PluginId: {Context.AppHost.PluginId}");
        
        var config = Context.Plugin.GetConfig<HelloWorldConfig>();
        if (!string.IsNullOrEmpty(config.Message))
        {
            NfExtensions.Logger.Log<PluginModule>(
                LogLevel.Information, $"The host application with the name of: {Context.AppHost.Name} says Hello {config.Message}");
        }
    }

    public override void Configure()
    {
        NfExtensions.Logger.Log<PluginModule>(
            LogLevel.Information, $"Configuring: {GetType().Name}");
        
        var range = ValidRanges.IsValidRange(102);
        if (range != null)
        {
            NfExtensions.Logger.Log<AppModuleOne>(
                LogLevel.Warning, $"102 is value range[{range.Item1}, {range.Item2}]");
        }
    }
}
using System;
using Examples.Bootstrapping.App.Plugin.Configs;
using Microsoft.Extensions.Logging;
using NetFusion.Common.Base;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Bootstrapping.App.Plugin.Modules;

public class AppModuleOne : PluginModule
{
    public override void Initialize()
    {
        NfExtensions.Logger.Log<PluginModule>(
            LogLevel.Information, $"Initializing: {GetType().Name}");
        
        NfExtensions.Logger.Log<PluginModule>(
            LogLevel.Information, $"Host PluginId: {Context.AppHost.PluginId}");
        
        var config = Context.Plugin.GetConfig<HelloWorldConfig>();
        if (!string.IsNullOrEmpty(config.Message))
        {
            Console.WriteLine(
                $"The host application with the name of: {Context.AppHost.Name} says Hello {config.Message}");
        }
    }

    public override void Configure()
    {
        NfExtensions.Logger.Log<PluginModule>(
            LogLevel.Information, $"Configuring: {GetType().Name}");
    }
}
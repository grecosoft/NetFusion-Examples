using Microsoft.Extensions.Logging;
using NetFusion.Common.Base;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Bootstrapping.CrossCut.Plugin.Modules;

public class CoreModuleOne : PluginModule
{
    public override void Initialize()
    {
        NfExtensions.Logger.Log<PluginModule>(
            LogLevel.Information, $"Initializing: {GetType().Name}");
    }

    public override void Configure()
    {
        NfExtensions.Logger.Log<PluginModule>(
            LogLevel.Information, $"Configuring: {GetType().Name}");
    }
}
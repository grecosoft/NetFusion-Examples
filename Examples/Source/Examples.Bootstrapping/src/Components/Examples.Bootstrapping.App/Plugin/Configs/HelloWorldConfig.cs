using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Bootstrapping.App.Plugin.Configs;

public class HelloWorldConfig : IPluginConfig
{
    public string Message { get; private set; } = "World";

    public void SetMessage(string message) => Message = message;
}
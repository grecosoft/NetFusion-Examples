using NetFusion.Bootstrap.Plugins;

namespace App.Component.Plugin.Configs
{
    public class HelloWorldConfig : IPluginConfig
    {
        public string Message { get; private set; } = "World";

        public void SetMessage(string message) => Message = message;
    }
}

using NetFusion.Bootstrap.Plugins;

namespace Core.Component.Plugin
{
    public interface IAddressValidation : IPluginModuleService
    {
        string IsValidAddress(string ip);
    }
}
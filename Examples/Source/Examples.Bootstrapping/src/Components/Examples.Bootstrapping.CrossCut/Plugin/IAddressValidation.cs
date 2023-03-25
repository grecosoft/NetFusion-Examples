using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Bootstrapping.CrossCut.Plugin;

public interface IAddressValidation : IPluginModuleService
{
    string? IsValidAddress(string ip);
}
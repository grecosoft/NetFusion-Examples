using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Bootstrapping.CrossCut;

public interface IAllowedIpAddresses : IPluginKnownType
{
    AllowedAddresses ListAllowedAddresses();
}
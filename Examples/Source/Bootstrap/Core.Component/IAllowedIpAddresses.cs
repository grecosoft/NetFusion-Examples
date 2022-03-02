using NetFusion.Base.Plugins;

namespace Core.Component
{
    public interface IAllowedIpAddresses : IKnownPluginType
    {
        AllowedAddresses ListAllowedAddresses();
    }
}

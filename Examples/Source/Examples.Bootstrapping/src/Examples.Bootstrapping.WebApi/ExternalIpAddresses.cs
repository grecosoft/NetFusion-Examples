using Examples.Bootstrapping.CrossCut;

namespace Examples.Bootstrapping.WebApi;

public class ExternalIpAddresses : IAllowedIpAddresses
{
    public AllowedAddresses ListAllowedAddresses() => new()
    {
        Source = $"Host.Plugin.Source[{nameof(ExternalIpAddresses)}]",
        IpAddresses = new []
        {
            "192.55.111.0",
            "192.56.321.0"
        }
    };
}
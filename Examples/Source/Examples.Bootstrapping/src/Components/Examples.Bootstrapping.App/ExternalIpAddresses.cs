using Examples.Bootstrapping.CrossCut;

namespace Examples.Bootstrapping.App;

public class ExternalIpAddresses : IAllowedIpAddresses
{
    public AllowedAddresses ListAllowedAddresses() => new()
    {
        Source = $"App.Plugin.Source1[{nameof(ExternalIpAddresses)}]",
        IpAddresses = new []
        {
            "192.88.105.0",
            "192.87.122.0"
        }
    };
}
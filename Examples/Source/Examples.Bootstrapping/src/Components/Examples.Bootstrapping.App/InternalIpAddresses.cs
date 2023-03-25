using Examples.Bootstrapping.CrossCut;

namespace Examples.Bootstrapping.App;

public class InternalIpAddresses : IAllowedIpAddresses
{
    public AllowedAddresses ListAllowedAddresses() => new()
    {
        Source = $"App.Plugin.Source2[{nameof(InternalIpAddresses)}]",
        IpAddresses = new []
        {
            "100.64.0.0",
            "169.254.0.0"
        }
    };
}
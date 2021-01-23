using Core.Component;

namespace App.Component
{
    public class ExternalIpAddresses : IAllowedIpAddresses
    {
        public AllowedAddresses ListAllowedAddresses() => new()
        {
            Source = $"App.Component[{nameof(ExternalIpAddresses)}]",
            IpAddresses = new []
            {
                "192.88.105.0",
                "192.87.122.0"
            }
        };
    }
}

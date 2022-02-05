using Core.Component;

namespace App.Component
{
    public class InternalIpAddresses : IAllowedIpAddresses
    {
        public AllowedAddresses ListAllowedAddresses() => new()
        {
            Source = $"App.Component[{nameof(InternalIpAddresses)}]",
            IpAddresses = new []
            {
                "100.64.0.0",
                "169.254.0.0"
            }
        };
    }
}

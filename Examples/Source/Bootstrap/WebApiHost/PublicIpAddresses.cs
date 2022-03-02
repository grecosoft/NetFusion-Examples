using Core.Component;

namespace WebApiHost
{
    public class ExternalIpAddresses : IAllowedIpAddresses
    {
        public AllowedAddresses ListAllowedAddresses() => new()
        {
            Source = $"App.Component[{nameof(ExternalIpAddresses)}]",
            IpAddresses = new []
            {
                "192.55.111.0",
                "192.56.321.0"
            }
        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using NetFusion.Bootstrap.Plugins;

namespace Core.Component.Plugin.Modules
{
    public class ValidAddressModule : PluginModule,
        IAddressValidation
    {
        public IEnumerable<IAllowedIpAddresses> AllowedAddresses { get; private set; }

        private AllowedAddresses[] _addresses;

        public override void Initialize()
        {
            Console.WriteLine($"Number of Allowed Address Components: {AllowedAddresses.Count()}");

            _addresses = AllowedAddresses.Select(a => a.ListAllowedAddresses()).ToArray();
        }

        public string IsValidAddress(string ip)
        {
            var address = _addresses.FirstOrDefault(a => a.IpAddresses.Contains(ip));
            return address?.Source;
        }

        public override void Log(IDictionary<string, object> moduleLog)
        {
            moduleLog["AllowedAddresses"] = _addresses.SelectMany(a => a.IpAddresses);
        }
    }
}

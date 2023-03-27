using Microsoft.Extensions.Logging;
using NetFusion.Common.Base;
using NetFusion.Core.Bootstrap.Plugins;

namespace Examples.Bootstrapping.CrossCut.Plugin.Modules;

public class ValidAddressModule : PluginModule,
    IAddressValidation
{
    public IEnumerable<IAllowedIpAddresses> AllowedAddresses { get; private set; } = Array.Empty<IAllowedIpAddresses>();

    private AllowedAddresses[] _addresses = Array.Empty<AllowedAddresses>();
    
    public override void Initialize()
    {
        NfExtensions.Logger.Log<ValidAddressModule>(
            LogLevel.Information, $"Number discovered implementations: {AllowedAddresses.Count()}");
        
        _addresses = AllowedAddresses.Select(a => a.ListAllowedAddresses()).ToArray();
    }

    public string? IsValidAddress(string ip)
    {
        var address = _addresses.FirstOrDefault(a => a.IpAddresses.Contains(ip));
        return address?.Source;
    }
    
    public override void Log(IDictionary<string, object> moduleLog)
    {
        moduleLog["AllowedAddresses"] = _addresses.SelectMany(a => a.IpAddresses).Distinct();
    }
}
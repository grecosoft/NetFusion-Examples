namespace Examples.Bootstrapping.CrossCut;

public class AllowedAddresses
{
    public string Source { get; set; } = "";
    public string[] IpAddresses { get; set; } = Array.Empty<string>();
}
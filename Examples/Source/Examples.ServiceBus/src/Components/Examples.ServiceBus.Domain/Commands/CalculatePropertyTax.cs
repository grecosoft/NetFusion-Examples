using NetFusion.Messaging.Types;

namespace Examples.ServiceBus.Domain.Commands;

[MessageNamespace("Accounting.PropertyTax")]
public class CalculatePropertyTax : Command<TaxCalc>
{
    public string Address { get; }
    public string City { get; }
    public string State { get; }
    public string Zip { get; }

    public CalculatePropertyTax(string address, string city, string state, string zip)
    {
        Address = address;
        City = city;
        State = state;
        Zip = zip;
    }
}

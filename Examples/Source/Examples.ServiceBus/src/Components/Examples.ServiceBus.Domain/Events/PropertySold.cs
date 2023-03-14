using NetFusion.Messaging.Types;

namespace Examples.ServiceBus.Domain.Events;

public class PropertySold : DomainEvent
{
    public string Address { get; }
    public string City { get; }
    public string State { get; }
    public string Zip { get; }
    public decimal AskingPrice { get; init; }
    public decimal SoldPrice { get; init; }

    public PropertySold(string address, string city, string state, string zip)
    {
        Address = address;
        City = city;
        State = state;
        Zip = zip;
    }
}
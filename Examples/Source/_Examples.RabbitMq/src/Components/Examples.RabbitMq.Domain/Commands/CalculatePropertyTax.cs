using Examples.RabbitMq.Domain.Entities;
using NetFusion.Messaging.Types;

namespace Examples.RabbitMq.Domain.Commands;

[MessageNamespace("PropertyTax")]
public class CalculatePropertyTax : Command<TaxCalc>
{
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }

    public CalculatePropertyTax(string address, string city, string state, string zip)
    {
        Address = address;
        City = city;
        State = state;
        Zip = zip;
    }
}

using Examples.RabbitMq.Domain.Entities;
using NetFusion.Messaging.Types;

namespace Examples.RabbitMq.Domain.Commands;

[MessageNamespace("AutoTax")]
public class CalculateAutoTax : Command<TaxCalc>
{
    public string Vin { get; set; } 
    public string ZipCode { get; set; }

    public CalculateAutoTax(string vin, string zipCode)
    {
        Vin = vin;
        ZipCode = zipCode;
    }
}
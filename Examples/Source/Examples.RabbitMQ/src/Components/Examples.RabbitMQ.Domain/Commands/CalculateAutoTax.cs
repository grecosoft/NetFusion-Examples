using NetFusion.Messaging.Types;

namespace Examples.RabbitMQ.Domain.Commands;

[MessageNamespace("Accounting.AutoTax")]
public class CalculateAutoTax : Command<TaxCalc>
{
    public string Vin { get; } 
    public string ZipCode { get; }

    public CalculateAutoTax(string vin, string zipCode)
    {
        Vin = vin;
        ZipCode = zipCode;
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Examples.RabbitMq.Domain.Commands;
using Examples.RabbitMq.Domain.Entities;

namespace Examples.RabbitMq.App.Handlers;

public class TaxCalculationHandler
{
    public async Task<TaxCalc> CalculatePropertyTax(CalculatePropertyTax command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        Console.WriteLine(command.State);

        if (command.State == "CT")
        {
            await Task.Delay(TimeSpan.FromSeconds(8), cancellationToken);
        }
        
        return command.State == "CT" ? new TaxCalc { Amount = 20_500, DateCalculated = DateTime.UtcNow}
            : new TaxCalc { Amount = 3_000, DateCalculated = DateTime.UtcNow };
    }
    
    public TaxCalc CalculateAutoTax(CalculateAutoTax command)
    {
        Console.WriteLine(command.ZipCode);

        return command.ZipCode == "06410" ? new TaxCalc { Amount = 1_000, DateCalculated = DateTime.UtcNow }
            : new TaxCalc { Amount = 200, DateCalculated = DateTime.UtcNow };
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Examples.ServiceBus.Domain.Commands;

namespace Examples.ServiceBus.App.Handlers;

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
        
        return command.State == "CT" ? new TaxCalc(20_500, DateTime.UtcNow)
            : new TaxCalc(3_000, DateTime.UtcNow);
    }
    
    public TaxCalc CalculateAutoTax(CalculateAutoTax command)
    {
        Console.WriteLine(command.ZipCode);

        return command.ZipCode == "06410" ? new TaxCalc(1_000, DateTime.UtcNow)
            : new TaxCalc(200, DateTime.UtcNow);
    }
}
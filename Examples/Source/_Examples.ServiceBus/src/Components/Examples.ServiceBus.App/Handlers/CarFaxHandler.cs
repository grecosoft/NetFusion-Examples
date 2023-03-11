using System.Threading.Tasks;
using Examples.ServiceBus.Domain.Commands;

namespace Examples.ServiceBus.App.Handlers;

public class CarFaxHandler
{
    public Task<CarFaxResult> GenerateReport(GenerateCarFax command)
    {
        return Task.FromResult(new CarFaxResult(100));
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Examples.ServiceBus.Domain.Events;
using NetFusion.Common.Extensions;

namespace Examples.ServiceBus.App.Handlers;

public class RealEstateHandler
{
    public async Task OnPropertySold(PropertySold domainEvent, CancellationToken token)
    {
        Console.WriteLine(nameof(OnPropertySold));
        
        await Task.Delay(TimeSpan.FromMilliseconds(1), token);
        Console.WriteLine(domainEvent.ToIndentedJson());
        
        token.ThrowIfCancellationRequested();
    }
}
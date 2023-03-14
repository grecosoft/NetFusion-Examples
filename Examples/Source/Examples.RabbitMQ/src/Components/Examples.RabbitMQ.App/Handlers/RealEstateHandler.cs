using System;
using System.Threading;
using System.Threading.Tasks;
using Examples.RabbitMQ.Domain.Events;
using NetFusion.Common.Extensions;

namespace Examples.RabbitMQ.App.Handlers;

public class RealEstateHandler
{
    public async Task OnNorthEastProperty(PropertySold domainEvent, CancellationToken token)
    {
        Console.WriteLine(nameof(OnNorthEastProperty));
        
        await Task.Delay(TimeSpan.FromMilliseconds(1), token);
        Console.WriteLine(domainEvent.ToIndentedJson());
        
        token.ThrowIfCancellationRequested();
    }
    
    public void OnSouthEastProperty(PropertySold domainEvent)
    {
        Console.WriteLine(nameof(OnSouthEastProperty));
        Console.WriteLine(domainEvent.ToIndentedJson());
    }
}
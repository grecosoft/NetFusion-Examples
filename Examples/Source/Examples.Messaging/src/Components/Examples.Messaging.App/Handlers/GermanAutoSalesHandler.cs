using System;
using System.Threading;
using System.Threading.Tasks;
using Examples.Messaging.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Examples.Messaging.App.Handlers;

public class GermanAutoSalesHandler
{
    private readonly ILogger<GermanAutoSalesHandler> _logger;
    
    public GermanAutoSalesHandler(ILogger<GermanAutoSalesHandler> logger)
    {
        _logger = logger;
    }
    
    public async Task OnRegistration(AutoSoldEvent domainEvent, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
      
        _logger.LogInformation("Domain Event Received by {handler} for {make} and {model}.", 
            nameof(GermanAutoSalesHandler), domainEvent.Make, domainEvent.Model);
    }
}
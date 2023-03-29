using Examples.Messaging.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Examples.Messaging.App.Handlers;

public class AmericanAutoSalesHandler
{
    private readonly ILogger<GermanAutoSalesHandler> _logger;
    
    public AmericanAutoSalesHandler(ILogger<GermanAutoSalesHandler> logger)
    {
        _logger = logger;
    }
    
    public void OnRegistration(AutoSoldEvent domainEvent)
    {
        _logger.LogInformation("Domain Event Received by {handler} for {make} and {model}.", 
            nameof(AmericanAutoSalesHandler), domainEvent.Make, domainEvent.Model);
    }
}
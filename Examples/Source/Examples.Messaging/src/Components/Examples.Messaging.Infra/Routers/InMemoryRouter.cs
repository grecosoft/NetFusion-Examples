using Examples.Messaging.App.Handlers;
using Examples.Messaging.Domain.Events;
using NetFusion.Messaging.InProcess;

namespace Examples.Messaging.Infra.Routers;

public class InMemoryRouter : MessageRouter
{
    protected override void OnConfigureRoutes()
    {
        OnDomainEvent<NewCustomerDomainEvent>(route =>
        {
            route.ToConsumer<CustomerHandler>(c => c.OnNewCustomer);
        });
    }
}
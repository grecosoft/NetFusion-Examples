using System.Linq;
using Examples.Messaging.App.Handlers;
using Examples.Messaging.Domain.Commands;
using Examples.Messaging.Domain.Entities;
using Examples.Messaging.Domain.Events;
using NetFusion.Messaging.InProcess;

namespace Examples.Messaging.Infra.Routers;

public class InMemoryRouter : MessageRouter
{
    protected override void OnConfigureRoutes()
    {
        OnDomainEvent<AutoSoldEvent>(route =>
            route.ToConsumer<GermanAutoSalesHandler>(c => c.OnRegistration, meta =>
                meta.When(de => new[]
                {
                    "BMW",
                    "Audi",
                    "Mercedes"
                }.Contains(de.Make))
            )
        );
        
        OnDomainEvent<AutoSoldEvent>(route =>
            route.ToConsumer<AmericanAutoSalesHandler>(c => c.OnRegistration, meta =>
                meta.When(de => new[]
                {
                    "Ford",
                    "Jeep",
                    "GMC"
                }.Contains(de.Make))
            )
        );
        
        OnDomainEvent<NewCustomerDomainEvent>(route =>
        {
            route.ToConsumer<CustomerHandler>(c => c.OnNewCustomer);
        });

        OnCommand<RegisterAutoCommand, RegistrationStatus>(route =>
            route.ToConsumer<AutoRegistrationHandler>(c => c.RegisterAuto));
    }
}
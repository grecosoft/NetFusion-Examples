using System;
using Examples.Messaging.Domain.Events;
using NetFusion.Common.Extensions;

namespace Examples.Messaging.App.Handlers;

public class CustomerHandler
{
    public void OnNewCustomer(NewCustomerDomainEvent domainEvent)
    {
        Console.WriteLine(domainEvent.ToIndentedJson());
    }
}
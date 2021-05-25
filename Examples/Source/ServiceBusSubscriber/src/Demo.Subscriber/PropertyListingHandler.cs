using System;
using Demo.Subscriber.Events;
using NetFusion.Azure.ServiceBus.Subscriber;
using NetFusion.Common.Extensions;
using NetFusion.Messaging;

namespace Demo.Subscriber
{
    public class PropertyListingHandler : IMessageConsumer
    {
        // Defines a subscription name all-properties having no configured 
        // filter that will receive all published domain-events.
        [TopicSubscription("netfusion-demo", "property-listing", "all-properties")]
        public void OnPropertyListed(NewListing domainEvent)
        {
            Console.WriteLine(domainEvent.ToIndentedJson());
        }
        
        // Defines a subscription named expensive-properties configured with a filter
        // limiting all received domain-events having a price greater than $250k.
        [TopicSubscription("netfusion-demo", "property-listing", "expensive-properties")]
        public void OnExpensivePropertyListed(NewListing domainEvent)
        {
            Console.WriteLine(domainEvent.ToIndentedJson());
        }
    }
}

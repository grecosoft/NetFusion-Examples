using Azure.Messaging.ServiceBus.Administration;
using Demo.Subscriber.Commands;
using NetFusion.Azure.ServiceBus.Namespaces;

namespace Demo.Subscriber
{
    /// <summary>
    /// Class defining configurations for Commands and DomainEvents.
    /// </summary>
    public class NamespaceRegistry : NamespaceRegistryBase
    {
        public NamespaceRegistry() : base("netfusion-demo") { }

        protected override void OnDefineNamespace()
        {
            // These are definitions of queues owned by this Microservice
            // to which other services sent commands for processing.
            CreateQueue<IssueMembershipCard>("card-issuance");
            CreateQueue<UpdateCarFaxReport>("car-fax-report");
            CreateRpcQueue("BizCalculations");
        }
        
        protected override void OnConfigureSubscriptions()
        {
            // Defines a subscription to which a domain-event handler can be subscribed.
            // Indicates that a subscription named expensive-properties, defined on the
            // property-listing topic, will be delivered all domain-events for which the
            // associated price is greater than $250k
            Subscription("property-listing", "expensive-properties", config =>
            {
                config.AddRule("expensive", new SqlRuleFilter("price > 250000") );
            });
        }
    }
}

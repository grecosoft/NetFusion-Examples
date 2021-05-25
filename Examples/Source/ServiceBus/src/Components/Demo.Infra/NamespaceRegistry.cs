using Demo.Domain.Commands;
using Demo.Domain.Events;
using NetFusion.Azure.ServiceBus.Namespaces;

namespace Demo.Infra
{
    /// <summary>
    /// This class contains the configuration of how Commands and DomainEvents
    /// are mapped to Service Bus entities.
    /// </summary>
    public class NamespaceRegistry : NamespaceRegistryBase
    {
        public NamespaceRegistry() : base("netfusion-demo") { }

        protected override void OnDefineNamespace()
        {
            // Indicates that when the IssueMembershipCar command is sent, it will be
            // delivered to the card-issuance queue.
            RouteToQueue<IssueMembershipCard>("card-issuance");
            
            // Indicates that when the UpdateCarFaxReport command is sent, it will be
            // delivered to the car-fax-report-queue and the corresponding response 
            // will be received on the car-fax-updates reply queue.
            RouteToQueue<UpdateCarFaxReport>("car-fax-report", queue =>
            {
                queue.ReplyToQueueName = "car-fax-updates";
            });
            
            // Defines a reply queue on which the CarFaxUpdateResult command responses
            // are received for previously sent commands.
            CreateResponseQueue<CarFaxUpdateResult>("car-fax-updates");
            
            // Define a RPC queue to which commands are sent and a near immediate response is received. 
            RouteToRpcQueue<CalculateRange>("BizCalculations");
            
            // Defines a topic to which NewListing domain-events are published for integration with
            // other Microservices.  
            CreateTopic<NewListing>("property-listing", config =>
            {
                // When a domain event is published, defines one or more application properties
                // on which consumers can use to define filters when subscribing.
                config.SetBusMessageProps((bm, m) =>
                {
                    bm.ApplicationProperties["price"] = m.ListedPrice;
                });
            });
            
            // Defines a topic to which NewSubmission domain-events are published for integration
            // with  other Microservices.
            CreateTopic<NewSubmission>("submissions");
        }
    }
}

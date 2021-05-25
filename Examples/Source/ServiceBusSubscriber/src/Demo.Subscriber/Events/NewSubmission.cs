using NetFusion.Messaging.Types;

namespace Demo.Subscriber.Events
{
    /// <summary>
    /// Domain event published by another Microservice to which
    /// this service subscribes.
    /// </summary>
    public class NewSubmission : DomainEvent
    {
        public string CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string State { get; set; }
    }
}

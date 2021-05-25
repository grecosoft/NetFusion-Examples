using NetFusion.Messaging.Types;

namespace Demo.Domain.Events
{
    /// <summary>
    /// This is an example of a domain event published to notify other
    /// Microservices of a change in state that they may be interested in.
    /// </summary>
    public class NewSubmission : DomainEvent
    {
        public string CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string State { get; set; }
    }
}

using NetFusion.Messaging.Types;

namespace Demo.Domain.Events
{
    /// <summary>
    /// This is an example of a domain event published to notify other
    /// Microservices of a change in state that they may be interested in.
    /// </summary>
    public class NewListing : DomainEvent
    {
        public string DataSource { get; set; }
        public string SourceId { get; set; }
        public decimal ListedPrice { get; set; }
        public string Realtor { get; set; }
        public int SquareFeet { get; set; }
        public string ZipCode { get; set; }
        public string Zip { get; set; }
    }
}

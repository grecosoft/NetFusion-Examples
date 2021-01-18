using NetFusion.Messaging.Types;

namespace Demo.Domain.Events
{
    public class NewListing : DomainEvent
    {
        public string DataSource { get; set; }
        public string SourceId { get; set; }
        public decimal ListedPrice { get; set; }
        public string Realtor { get; set; }
        public int SquareFeet { get; set; }
        public int ZipCode { get; set; }
        public string Zip { get; set; }
    }
}

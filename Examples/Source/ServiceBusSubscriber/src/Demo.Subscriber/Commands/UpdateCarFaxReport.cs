using System;
using NetFusion.Messaging.Types;

namespace Demo.Subscriber.Commands
{
    /// <summary>
    /// Command sent by another Microservice for processing.  The response
    /// is returned to the invoking services on a reply queue.
    /// </summary>
    public class UpdateCarFaxReport : Command<CarFaxUpdateResult>
    {
        public string Vin { get; set; }
        public DateTime DateOfService { get; set; }
        public string Service { get; set; }
        public int NumberOfOwners { get; set; }
        public bool IsTotalLoss { get; set; }
        public int Miles { get; set; }
    }
}

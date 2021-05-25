using System;
using NetFusion.Messaging.Types;

namespace Demo.Domain.Commands
{
    /// <summary>
    /// This is an example command sent to a Queue subscribed to by another Microservice.
    /// Since the response to this command is truly asynchronous and received on a reply queue,
    /// the non-generic base command, not specifying an immediate response type, type is used.
    /// </summary>
    public class UpdateCarFaxReport : Command  // CarFaxUpdateResult
    {
        public string Vin { get; set; }
        public DateTime DateOfService { get; set; }
        public string Service { get; set; }
        public int NumberOfOwners { get; set; }
        public bool IsTotalLoss { get; set; }
        public int Miles { get; set; }
    }
}



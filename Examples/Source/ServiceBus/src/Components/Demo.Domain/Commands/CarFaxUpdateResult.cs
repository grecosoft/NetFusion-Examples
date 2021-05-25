using NetFusion.Messaging.Types;

namespace Demo.Domain.Commands
{
    /// <summary>
    /// This class represents the result of the UpdateCarFaxReport
    /// returned asynchronously on the sent command's reply queue.
    /// Since this is a response to an previously sent command, the
    /// class derives by the base Message type.
    /// </summary>
    public class CarFaxUpdateResult : Message
    {
        public string ReportId { get; set; }
        public string ReportUrl { get; set; }
        public string ResultStatus { get; set; }
    }
}

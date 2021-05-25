using System;
using System.Threading.Tasks;
using Demo.Subscriber.Commands;
using NetFusion.Azure.ServiceBus.Subscriber;
using NetFusion.Common.Extensions;
using NetFusion.Messaging;

namespace Demo.Subscriber
{
    public class AutoProcessing : IMessageConsumer
    {
        /// <summary>
        /// Example of a Command handler subscribed to the car-fax-report
        /// queue on the netfussion-demo namespace.
        /// </summary>
        [QueueSubscription("netfusion-demo", "car-fax-report")]
        public CarFaxUpdateResult OnUpdateReport(UpdateCarFaxReport command)
        {
            Console.WriteLine(command.ToIndentedJson());

            var reportId = Guid.NewGuid().ToString();
            
            // This response will be sent back to the caller if it specified
            // a corresponding reply queue when sending the command.
            return new CarFaxUpdateResult
            {
                ReportId = reportId,
                ReportUrl = $"http://www.carfax.com/reports/{reportId}",
                ResultStatus = "Completed"
            };
        }
    }
}

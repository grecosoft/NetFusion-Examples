using System;
using Demo.Domain.Commands;
using NetFusion.Azure.ServiceBus.Subscriber;
using NetFusion.Common.Extensions;
using NetFusion.Messaging;

namespace Demo.App.Services
{
    public class CarFaxResponsesHandler : IMessageConsumer
    {
        /// <summary>
        /// This is an example of a handler linked to a reply queue on which
        /// responses to  previously sent asynchronous commands are received.
        /// </summary>
        /// <param name="result"></param>
        [QueueSubscription("netfusion-demo", "car-fax-updates")]
        public void OnCarFaxUpdated(CarFaxUpdateResult result)
        {
            Console.Write(result.ToIndentedJson());
        }
    }
}

using System;
using System.Linq;
using Demo.Subscriber.Commands;
using NetFusion.Azure.ServiceBus.Subscriber;
using NetFusion.Common.Extensions;
using NetFusion.Messaging;

namespace Demo.Subscriber
{
    public class CalculationHandler : IMessageConsumer
    {
        /// <summary>
        /// This is an example of a command handler sent from another Microservice
        /// expecting a near immediate reply. 
        /// </summary>
        [RpcQueueSubscription("netfusion-demo", "BizCalculations")]
        public ValueRange OnCalRange(CalculateRange command)
        {
            Console.WriteLine(command.ToIndentedJson());
            return new ValueRange
            {
                MinValue = command.Values.Min(),
                MaxValue = command.Values.Max()
            };
        }
    }
}

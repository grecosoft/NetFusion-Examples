using System;
using Demo.Subscriber.Events;
using NetFusion.Common.Extensions;
using NetFusion.Messaging;
using NetFusion.Redis.Subscriber;

namespace Demo.Subscriber
{
    public class OrderSubmittedHandler : IMessageConsumer
    {
        [ChannelSubscription("testdb", "Orders.*.CT")]
        public void OnSubmission(OrderSubmitted orderEvt)
        {
            Console.WriteLine(orderEvt.ToIndentedJson());
        }
    }
}
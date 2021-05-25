using System;
using Demo.Subscriber.Events;
using NetFusion.Azure.ServiceBus.Subscriber;
using NetFusion.Common.Extensions;
using NetFusion.Messaging;

namespace Demo.Subscriber
{
    public class SubmissionHandler : IMessageConsumer
    {
        /// <summary>
        /// Defines a subscription on a topic called when a domain-event is
        /// published to the submissions topic.  The subscription is named
        /// notify and since the IsFanout property is specified, each Microservice
        /// creates its own subscription so all running instances are notified.
        /// </summary>
        [TopicSubscription("netfusion-demo", "submissions", "notify", IsFanout = true)]
        public void OnSubmission(NewSubmission domainEvent)
        {
            Console.WriteLine(domainEvent.ToIndentedJson());
        }
    }
}

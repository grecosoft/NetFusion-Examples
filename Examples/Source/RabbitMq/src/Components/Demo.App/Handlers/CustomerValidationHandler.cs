using System;
using Demo.Domain.Commands;
using NetFusion.Common.Extensions;
using NetFusion.Messaging;
using NetFusion.RabbitMQ.Subscriber;

namespace Demo.App.Handlers
{
    public class CustomerValidationHandler : IMessageConsumer
    {
        [WorkQueue("testBus", "CustomerValidationResponses")]
        public void OnValidationResult(ValidationResult result)
        {
            Console.WriteLine(result.ToIndentedJson());
        }
    }
}
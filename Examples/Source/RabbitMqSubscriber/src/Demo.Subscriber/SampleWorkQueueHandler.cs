using System;
using Demo.Subscriber.Commands;
using NetFusion.Common.Extensions;
using NetFusion.Messaging;
using NetFusion.RabbitMQ.Publisher;
using NetFusion.RabbitMQ.Subscriber;

namespace Demo.Subscriber
{
    public class SampleWorkQueueHandler : IMessageConsumer
    {
        private readonly IQueueResponseService _queueResponse;
        
        public SampleWorkQueueHandler(IQueueResponseService queueResponse)
        {
            _queueResponse = queueResponse;
        }
        
        [WorkQueue("testBus", "GenerateAndSendEmail")]
        public void GenerateEmail(SendEmail email)
        {
            Console.WriteLine(email.ToIndentedJson());
        }
        
        [WorkQueue("testBus", "CustomerLookup")]
        public ValidationResult ValidateCustomer(ValidateCustomer command)
        {
            Console.WriteLine(command.ToIndentedJson());

            return new ValidationResult
            {
                IsValue = true,
                StatusMessage = "Customer Passed Validation Checks"
            };
        }
    }
}

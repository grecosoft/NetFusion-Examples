using System;
using System.Threading;
using System.Threading.Tasks;
using NetFusion.Common.Extensions;
using NetFusion.Messaging;
using NetFusion.Messaging.Internal;
using NetFusion.Messaging.Types.Contracts;

namespace Examples.Messaging.Infra;

public class PrintMessagePublisher : IMessagePublisher
{
    public IntegrationTypes IntegrationType => IntegrationTypes.Internal;
    
    public Task PublishMessageAsync(IMessage message, CancellationToken cancellationToken)
    {
        if (message.Attributes.TryGetValue("print", out string? color))
        {
            var printColor = Enum.TryParse(color, ignoreCase: true,
                out ConsoleColor consoleColor) ? consoleColor : ConsoleColor.Gray;

            Console.ForegroundColor = printColor;
            Console.WriteLine(message.ToIndentedJson());
        }

        return Task.CompletedTask;
    }
}
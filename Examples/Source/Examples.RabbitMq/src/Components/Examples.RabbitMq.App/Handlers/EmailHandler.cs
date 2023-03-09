using System;
using Examples.RabbitMQ.Domain.Commands;
using NetFusion.Common.Extensions;

namespace Examples.RabbitMQ.App.Handlers;

public class EmailHandler
{
    public void OnSendEmail(SendEmail command)
    {
        Console.WriteLine(nameof(OnSendEmail));
        Console.WriteLine(command.ToIndentedJson());
    }
}
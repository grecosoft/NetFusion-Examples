using System;
using Examples.ServiceBus.Domain.Commands;
using NetFusion.Common.Extensions;

namespace Examples.ServiceBus.App.Handlers;

public class EmailHandler
{
    public void OnSendEmail(SendEmail command)
    {
        Console.WriteLine(nameof(OnSendEmail));
        Console.WriteLine(command.ToIndentedJson());
    }
}
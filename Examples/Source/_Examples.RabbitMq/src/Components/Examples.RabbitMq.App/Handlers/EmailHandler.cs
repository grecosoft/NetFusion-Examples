using System;
using Examples.RabbitMq.Domain.Commands;
using NetFusion.Common.Extensions;

namespace Examples.RabbitMq.App.Handlers;

public class EmailHandler
{
    public void GenerateEmail(SendEmail email)
    {
        Console.WriteLine(email.ToIndentedJson());
    }
}
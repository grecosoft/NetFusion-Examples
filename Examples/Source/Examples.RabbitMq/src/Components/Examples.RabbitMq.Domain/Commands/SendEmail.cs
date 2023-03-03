using System;
using NetFusion.Messaging.Types;

namespace Examples.RabbitMq.Domain.Commands;

public class SendEmail : Command
{
    public string? Subject { get; set; }
    public string? FromAddress { get; set; }
    public string[] ToAddresses { get; set; } = Array.Empty<string>();
    public string? Message { get; set; }
    
}
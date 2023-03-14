using NetFusion.Messaging.Types;

namespace Examples.RabbitMQ.Domain.Commands;

public class SendEmail : Command
{
    public string Subject { get; }
    public string FromAddress { get; }
    public string[] ToAddresses { get; }
    public string Message { get; }

    public SendEmail(string subject, string fromAddress, string[] toAddresses, string message)
    {
        Subject = subject;
        FromAddress = fromAddress;
        ToAddresses = toAddresses;
        Message = message;
    }
}
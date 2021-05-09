using NetFusion.Messaging.Types;

namespace Demo.Domain.Commands
{
    public class ValidationResult : Message
    {
        public bool IsValue { get; set; }
        public string StatusMessage { get; set; }
        public string[] Addresses { get; set; }
    }
}
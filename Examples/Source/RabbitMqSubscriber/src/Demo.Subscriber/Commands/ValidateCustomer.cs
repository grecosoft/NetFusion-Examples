using NetFusion.Messaging.Types;

namespace Demo.Subscriber.Commands
{
    public class ValidateCustomer : Command<ValidationResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }

    public class ValidationResult
    {
        public bool IsValue { get; set; }
        public string StatusMessage { get; set; }
        public string[] Addresses { get; set; }
    }
}
using NetFusion.Messaging.Types;

namespace Demo.Domain.Commands
{
    public class ValidateCustomer : Command
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }
}
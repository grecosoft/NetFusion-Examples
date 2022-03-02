using NetFusion.Messaging.Types;

namespace Demo.Domain.Events
{
    public class NewCustomerDomainEvent : DomainEvent
    {
        public string FirstName { get; }
        public string LastName { get; }

        public NewCustomerDomainEvent(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}

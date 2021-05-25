using System;
using NetFusion.Messaging.Types;

namespace Demo.Subscriber.Commands
{
    /// <summary>
    /// Example of a command submitted by another Microservice
    /// for which there is no corresponding response.
    /// </summary>
    public class IssueMembershipCard : Command
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}

using NetFusion.Messaging.Types;

namespace Demo.Subscriber.Commands
{
    /// <summary>
    /// Example of a RPC command sent by another Microservice
    /// expecting a near immediate asynchronous response. 
    /// </summary>
    [MessageNamespace("demo.examples.cal.range")]
    public class CalculateRange : Command<ValueRange>
    {
        public int[] Values { get; set; }
    }
}

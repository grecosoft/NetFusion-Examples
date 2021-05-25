using NetFusion.Messaging.Types;

namespace Demo.Domain.Commands
{
    /// <summary>
    /// This is an example of an RPC command where the response is asynchronous
    /// but will be received in a very short amount of time on a corresponding
    /// reply queue. 
    /// </summary>
    [MessageNamespace("demo.examples.cal.range")]
    public class CalculateRange : Command<ValueRange>
    {
        public int[] Values { get; set; }
    }
}

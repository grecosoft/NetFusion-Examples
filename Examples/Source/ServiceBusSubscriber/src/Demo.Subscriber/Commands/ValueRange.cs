namespace Demo.Subscriber.Commands
{
    /// <summary>
    /// Response to a RPC command.
    /// </summary>
    public class ValueRange
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}

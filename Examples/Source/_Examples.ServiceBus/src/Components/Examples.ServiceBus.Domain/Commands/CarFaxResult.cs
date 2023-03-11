using NetFusion.Messaging.Types;

namespace Examples.ServiceBus.Domain.Commands;

public class CarFaxResult : Command
{
    public int Score { get; private set; }
    
    public CarFaxResult(int score)
    {
        Score = score;
    }
}
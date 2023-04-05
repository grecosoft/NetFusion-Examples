using System.Linq;
using System.Threading.Tasks;
using Examples.Messaging.Domain.Commands;
using NetFusion.Messaging.Filters;
using NetFusion.Messaging.Types.Attributes;
using NetFusion.Messaging.Types.Contracts;

namespace Examples.Messaging.Infra;

public class ScoreMessageFilter : IPreMessageFilter, IPostMessageFilter
{
    public Task OnPreFilterAsync(IMessage message)
    {
        if (message is IScoredMessage scoredMessage)
        {
            message.Attributes.SetIntValue("PreMaxScore", scoredMessage.Scores.Max());
        }
        
        return Task.CompletedTask;
    }

    public Task OnPostFilterAsync(IMessage message)
    {
        if (message is IScoredMessage scoredMessage)
        {
            message.Attributes.SetIntValue("PostMaxScore", scoredMessage.Results.Max());
        }

        return Task.CompletedTask;
    }
    
}
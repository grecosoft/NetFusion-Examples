using System;
using System.Collections.Generic;
using Examples.Messaging.Domain.Entities;
using NetFusion.Messaging.Types;

namespace Examples.Messaging.Domain.Commands;

public class PublishScoresCommand : Command<PublishedScoreResult>,
    IScoredMessage
{
    public IEnumerable<int> Scores { get; }
    
    public PublishScoresCommand(IEnumerable<int> scores)
    {
        Scores = scores;
    }

    public IEnumerable<int> Results => Result?.PublishedScores ?? Array.Empty<int>();
}
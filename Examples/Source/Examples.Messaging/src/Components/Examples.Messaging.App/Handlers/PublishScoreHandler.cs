using System;
using System.Linq;
using Examples.Messaging.Domain.Commands;
using Examples.Messaging.Domain.Entities;

namespace Examples.Messaging.App.Handlers;

public class PublishScoreHandler
{
    public PublishedScoreResult OnPublish(PublishScoresCommand command)
    {
        var random = new Random();

        var updatedScores = command.Scores.Select(s => s + random.Next(0, 50)).ToArray();
        return new PublishedScoreResult(updatedScores);
    }
}
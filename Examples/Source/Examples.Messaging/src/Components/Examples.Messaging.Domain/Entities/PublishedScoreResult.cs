using System.Collections.Generic;

namespace Examples.Messaging.Domain.Entities;

public class PublishedScoreResult
{
    public IEnumerable<int> PublishedScores { get; }

    public PublishedScoreResult(int[] publishedScores)
    {
        PublishedScores = publishedScores;
    }
}

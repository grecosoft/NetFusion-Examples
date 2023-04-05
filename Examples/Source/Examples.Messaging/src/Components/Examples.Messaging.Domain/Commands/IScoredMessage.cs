using System.Collections.Generic;

namespace Examples.Messaging.Domain.Commands;

public interface IScoredMessage
{
    public IEnumerable<int> Scores { get; }
    public IEnumerable<int> Results { get; }
}
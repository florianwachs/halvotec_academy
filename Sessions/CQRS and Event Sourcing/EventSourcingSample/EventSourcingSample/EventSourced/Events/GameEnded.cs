using EventSourcingSample.Abstract;
using System;

namespace EventSourcingSample.EventSourced.Events
{

    public class GameEnded : SoccerDomainEvent
    {
        public string GameId { get; set; }

        public GameEnded()
        {
        }

        public GameEnded(string gameId, DateTime timestamp) : base(gameId, timestamp)
        {
        }

        public override IDomainEvent<string> WithAggregate(string aggregateId, long aggregateVersion)
        {
            AggregateId = aggregateId;
            return this;
        }
    }
}

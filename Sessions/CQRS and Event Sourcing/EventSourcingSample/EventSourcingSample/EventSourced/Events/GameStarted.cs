using EventSourcingSample.Abstract;
using System;

namespace EventSourcingSample.EventSourced.Events
{
    public class GameStarted : SoccerDomainEvent
    {
        public string GameId { get; set; }

        public GameStarted()
        {
        }

        public GameStarted(string gameId, DateTime timestamp) : base(gameId, timestamp)
        {
        }

        public override IDomainEvent<string> WithAggregate(string aggregateId, long aggregateVersion)
        {
            AggregateId = aggregateId;
            return this;
        }
    }
}

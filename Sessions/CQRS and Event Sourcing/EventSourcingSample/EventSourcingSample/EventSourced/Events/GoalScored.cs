using EventSourcingSample.Abstract;
using System;

namespace EventSourcingSample.EventSourced.Events
{

    public class GoalScored : SoccerDomainEvent
    {
        public string TeamId { get; set; }
        public string PlayerId { get; set; }

        public GoalScored()
        {
        }

        public GoalScored(string gameId, DateTime timestamp, string teamId, string playerId) : base(gameId, timestamp)
        {
            TeamId = teamId;
            PlayerId = playerId;
        }


        public override IDomainEvent<string> WithAggregate(string aggregateId, long aggregateVersion)
        {
            AggregateId = aggregateId;
            return this;
        }
    }
}

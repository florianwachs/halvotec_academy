using EventSourcingSample.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSample.EventSourced.Events
{
    public class GameCreated : SoccerDomainEvent
    {
        public string GameId { get; set; }
        public string HomeTeamId { get; set; }
        public string GuestTeamId { get; set; }

        public GameCreated()
        {
        }

        public GameCreated(string gameId, string homeTeamId, string guestTeamId, DateTime timestamp) : base(gameId, timestamp)
        {
            GameId = gameId;
            HomeTeamId = homeTeamId;
            GuestTeamId = guestTeamId;
        }

        public override IDomainEvent<string> WithAggregate(string aggregateId, long aggregateVersion)
        {
            AggregateId = aggregateId;
            return this;
        }
    }
}

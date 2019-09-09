using EventSourcingSample.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSample.EventSourced.Events
{
    public abstract class SoccerDomainEvent : DomainEventBase<string>
    {
        public SoccerDomainEvent()
        {
        }

        public SoccerDomainEvent(string gameId, DateTime timestamp) : base(gameId)
        {
            AggregateId = gameId;
            Timestamp = timestamp;
        }

        public DateTime Timestamp { get; set; }
    }
}

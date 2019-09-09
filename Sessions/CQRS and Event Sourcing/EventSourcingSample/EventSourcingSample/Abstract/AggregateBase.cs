using System.Collections.Generic;
using System.Linq;

namespace EventSourcingSample.Abstract
{
    public abstract class AggregateBase : Entity, IEventSourcingAggregate<string>
    {
        public const long NewAggregateVersion = -1;

        private readonly ICollection<IDomainEvent<string>> _uncommittedEvents =
          new LinkedList<IDomainEvent<string>>();
        private long _version = NewAggregateVersion;

        long IEventSourcingAggregate<string>.Version => _version;

        void IEventSourcingAggregate<string>.ApplyEvent(IDomainEvent<string> @event, long version)
        {
            if (!_uncommittedEvents.Any(x => Equals(x.EventId, @event.EventId)))
            {
                ((dynamic)this).Apply((dynamic)@event);
                _version = version;
            }
        }

        void IEventSourcingAggregate<string>.ClearUncommittedEvents()
        {
            _uncommittedEvents.Clear();
        }

        IEnumerable<IDomainEvent<string>> IEventSourcingAggregate<string>.GetUncommittedEvents()
        {
            return _uncommittedEvents.AsEnumerable();
        }

        protected void RaiseEvent<TEvent>(TEvent @event)
            where TEvent : DomainEventBase<string>
        {
            IDomainEvent<string> eventWithAggregate = @event.WithAggregate(
              string.IsNullOrEmpty(Id) ? @event.AggregateId : Id,
              _version);

            ((IEventSourcingAggregate<string>)this).ApplyEvent(eventWithAggregate, _version + 1);
            _uncommittedEvents.Add(@event);
        }
    }
}

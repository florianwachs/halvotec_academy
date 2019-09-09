using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSample.Abstract
{
    public abstract class DomainEventBase<TAggregateId> : IDomainEvent<TAggregateId>, IEquatable<DomainEventBase<TAggregateId>>
    {
        protected DomainEventBase() => EventId = Guid.NewGuid();

        protected DomainEventBase(TAggregateId aggregateId) : this() => AggregateId = aggregateId;

        protected DomainEventBase(TAggregateId aggregateId, long aggregateVersion) : this(aggregateId) => AggregateVersion = aggregateVersion;

        public Guid EventId { get; private set; }

        public TAggregateId AggregateId { get; protected set; }

        public long AggregateVersion { get; protected set; }

        public override bool Equals(object obj) => base.Equals(obj as DomainEventBase<TAggregateId>);

        public bool Equals(DomainEventBase<TAggregateId> other) => other != null &&
                   EventId.Equals(other.EventId);

        public override int GetHashCode() => 290933282 + EqualityComparer<Guid>.Default.GetHashCode(EventId);

        public abstract IDomainEvent<TAggregateId> WithAggregate(TAggregateId aggregateId, long aggregateVersion);
    }
}

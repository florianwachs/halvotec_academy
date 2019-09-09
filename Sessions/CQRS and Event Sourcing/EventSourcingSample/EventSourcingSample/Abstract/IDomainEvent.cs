using System;

namespace EventSourcingSample.Abstract
{
    public interface IDomainEvent<TAggregateId>
    {
        Guid EventId { get; }
        TAggregateId AggregateId { get; }
        long AggregateVersion { get; }
    }
}

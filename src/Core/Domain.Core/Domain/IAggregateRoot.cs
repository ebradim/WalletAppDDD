namespace Domain.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal interface IAggregateRoot<TKey>
    {
        TKey Id { get; }
        long Version { get; }
        void ClearUncommittedEvents();
        IEnumerable<IDomainEvent> GetUncommittedEvents();
    }
}

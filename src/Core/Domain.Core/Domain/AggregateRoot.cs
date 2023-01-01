namespace Domain.Core.Domain
{
    using Marten.Schema;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class AggregateRoot<TKey> : IAggregateRoot<TKey> where TKey : StrongTypeId<Guid>
    {
        public AggregateRoot()
        {
        }
        public TKey Id { get; } = default!;

        [Identity]
        public Guid AggregateId
        {

            get => Id.Value;
            set { }
        }
        public long Version { get; }

        public void ClearUncommittedEvents()
        {
            domainEvents.Clear();
        }

        public IEnumerable<IDomainEvent> GetUncommittedEvents()
        {
            return domainEvents;
        }
        public void AppendEvent(IDomainEvent @event)
        {
            domainEvents.Enqueue(@event);
        }

        [JsonIgnore]
        private readonly Queue<IDomainEvent> domainEvents= new();
    }
}

using Abstracts.Event_Sourcing;
using System.Collections.Generic;
using System.Linq;

namespace Abstracts.DDD
{
    public abstract class AggregateRoot
    {
        public int Key { get; protected set; }

        private readonly List<IDomainEvent> DomainEvents = new List<IDomainEvent>();

        protected void AddDomainEvent(IDomainEvent eventItem)
        {
            DomainEvents.Add(eventItem);
        }

        public IEnumerable<IDomainEvent> GetDomainEvents() => DomainEvents.AsEnumerable();

        public void ClearDomainEvents() => DomainEvents.Clear();
    }
}

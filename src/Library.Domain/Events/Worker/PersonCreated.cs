using Abstracts.Event_Sourcing;
using MediatR;

namespace Domain.Events.Worker
{
    public class PersonCreated : IDomainEvent, INotification
    {
        public Guid PersonId { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public PersonCreated(Guid personId, string firstName, string lastName)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}

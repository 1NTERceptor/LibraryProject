using Abstracts.Event_Sourcing;
using MediatR;

namespace Library.Messages.Events.Worker
{
    public class PersonCreated : IDomainEvent, INotification
    {
        public int PersonId { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public PersonCreated(int personId, string firstName, string lastName)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}

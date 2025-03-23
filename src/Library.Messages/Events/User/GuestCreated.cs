using Library.Messages.Events.Worker;

namespace Library.Messages.Events.User
{
    public class GuestCreated : PersonCreated
    {
        public GuestCreated(Guid personId, string firstName, string lastName) : base(personId, firstName, lastName)
        {
        }
    }
}

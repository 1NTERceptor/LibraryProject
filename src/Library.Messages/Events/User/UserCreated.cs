using Library.Messages.Events.Worker;

namespace Library.Messages.Events.User
{
    public class UserCreated : PersonCreated
    {
        public UserCreated(Guid personId, string firstName, string lastName) : base(personId, firstName, lastName)
        {
        }
    }
}

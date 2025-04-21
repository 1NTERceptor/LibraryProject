using Domain.Events.Worker;
using System;

namespace Domain.Events.User
{
    public class UserCreated : PersonCreated
    {
        public UserCreated(Guid personId, string firstName, string lastName) : base(personId, firstName, lastName)
        {
        }
    }
}

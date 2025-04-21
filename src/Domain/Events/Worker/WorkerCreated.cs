using System;

namespace Domain.Events.Worker
{
    public class WorkerCreated : PersonCreated
    {
        public WorkerCreated(Guid personId, string firstName, string lastName) : base(personId, firstName, lastName)
        {
        }
    }
}

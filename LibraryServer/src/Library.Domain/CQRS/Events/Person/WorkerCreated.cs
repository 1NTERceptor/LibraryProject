namespace Library.Domain.CQRS.Events.Person
{
    public class WorkerCreated : PersonCreated
    {
        public WorkerCreated(int personId, string firstName, string lastName) : base(personId, firstName, lastName)
        {
        }
    }
}

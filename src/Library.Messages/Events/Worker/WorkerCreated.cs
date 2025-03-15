namespace Library.Messages.Events.Worker
{
    public class WorkerCreated : PersonCreated
    {
        public WorkerCreated(int personId, string firstName, string lastName) : base(personId, firstName, lastName)
        {
        }
    }
}

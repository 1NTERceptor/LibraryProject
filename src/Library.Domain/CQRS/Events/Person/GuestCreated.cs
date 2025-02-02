namespace Library.Domain.CQRS.Events.Person
{
    public class GuestCreated : PersonCreated
    {
        public GuestCreated(int personId, string firstName, string lastName) : base(personId, firstName, lastName)
        {
        }
    }
}

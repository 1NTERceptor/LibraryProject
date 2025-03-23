namespace Library.Messages.Models
{
    public abstract class PersonModelBase
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public PersonModelBase() { }

        public PersonModelBase(Guid id, string login, string firstName, string lastName, string city)
        {
            Id = id;
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            City = city;
        }
    }
}

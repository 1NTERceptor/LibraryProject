namespace Library.Messages.Models
{
    public abstract class PersonModelBase
    {
        public Guid Key { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public PersonModelBase() { }
    }
}

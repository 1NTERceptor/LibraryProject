namespace Library.Domain.Models
{
    public abstract class ModelBase
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public ModelBase() { }

        public ModelBase(int id, string login, string firstName, string lastName, string city)
        {
            Id = id;
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            City = city;
        }
    }
}

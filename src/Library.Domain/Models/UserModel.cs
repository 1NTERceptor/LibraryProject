namespace Library.Domain.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string  Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string GuestCardNumber { get; set; }

        public UserModel() { }

        public UserModel(int id, string login, string firstName, string lastName, string city, string guestCardNumber)
        {
            Id = id;
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            GuestCardNumber = guestCardNumber;
        }
    }
}

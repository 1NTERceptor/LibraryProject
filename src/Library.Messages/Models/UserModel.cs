namespace Library.Messages.Models
{
    public class UserModel : ModelBase
    {
        public string GuestCardNumber { get; set; }

        public UserModel() { }

        public UserModel(int id, string login, string firstName, string lastName, string city, string guestCardNumber) 
            : base(id, login, firstName, lastName, city)
        {
            GuestCardNumber = guestCardNumber;
        }
    }
}

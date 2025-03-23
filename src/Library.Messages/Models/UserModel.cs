namespace Library.Messages.Models
{
    public class UserModel : PersonModelBase
    {
        public string GuestCardNumber { get; set; }

        public UserModel() { }

        public UserModel(Guid id, string login, string firstName, string lastName, string city, string guestCardNumber) 
            : base(id, login, firstName, lastName, city)
        {
            GuestCardNumber = guestCardNumber;
        }
    }
}

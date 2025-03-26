using Library.Messages.Events.User;
using System.Collections.Generic;

namespace Library.Domain.Aggregates
{
    public class User : Person
    {
        public string GuestCardNumber { get; private set; }

        public string City { get; private set; }

        public List<Loan> Loans { get; private set; } = new List<Loan>();

        public static User CreateUser(string firstName, string lastName, string guestCardNumber, string login)
        {
            return new User(firstName,  lastName, guestCardNumber, login);
        }

        public User() { }

        private User(string firstName, string lastName, string guestCardNumber, string login) : base(firstName, lastName, login) 
        {
            GuestCardNumber = guestCardNumber;

            AddDomainEvent(new GuestCreated(Key, firstName, lastName));
        }
    }
}

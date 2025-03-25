using Library.Messages.Events.User;
using System;
using System.Collections.Generic;
using Library.Domain.Aggregates.Loan;

namespace Library.Domain.Aggregates
{
    public class User : Person
    {
        public string GuestCardNumber { get; private set; }

        public string City { get; private set; }

        public List<Library.Domain.Aggregates.Loan.Loan> Loans { get; private set; } = new List<Library.Domain.Aggregates.Loan.Loan>();

        public Guid LoanId { get; set; }

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

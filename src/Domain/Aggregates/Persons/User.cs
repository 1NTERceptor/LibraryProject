﻿using Domain.Aggregates.Loans;
using Domain.Events.User;
using System.Collections.Generic;

namespace Domain.Aggregates.Persons
{
    public class User : Person
    {
        public string GuestCardNumber { get; protected set; }

        public string City { get; protected set; }

        public List<Loan> Loans { get; protected set; } = new List<Loan>();

        public static User CreateUser(string firstName, string lastName, string guestCardNumber, string login)
        {
            return new User(firstName,  lastName, guestCardNumber, login);
        }

        public User() { }

        private User(string firstName, string lastName, string guestCardNumber, string login) : base(firstName, lastName, login) 
        {
            GuestCardNumber = guestCardNumber;

            AddDomainEvent(new UserCreated(Key, firstName, lastName));
        }

        public void BorrowBook(Loan loan)
        {
            if(Loans.Count >= 5)
                throw new System.ArgumentException("Nie można wypożyczyć więcej niż 5 książek");

            Loans.Add(loan);
        }

        public void ReturnBook(Loan loan)
        {
            Loans.Remove(loan);
        }
    }
}

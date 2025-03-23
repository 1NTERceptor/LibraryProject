using Abstracts.DDD;
using System;

namespace Library.Domain.Aggregates
{
    public abstract class Person : AggregateRoot
    {
        public string Login { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Person() { }
        public Person(string firstName, string lastName, string login)
        {
            Key = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Login = login;
        }        
    }
}

using Abstracts.DDD;

namespace Library.Domain.Aggregates
{
    public class Person : AggregateRoot
    {
        public string Login { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Person() { }
        public Person(string firstName, string lastName, string login)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
        }        
    }
}

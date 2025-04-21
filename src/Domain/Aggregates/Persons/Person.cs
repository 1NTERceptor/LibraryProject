using SharedKernel.DDD;

namespace Domain.Aggregates.Persons
{
    public abstract class Person : AggregateRoot
    {
        public string Login { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public Person() { }

        public Person(string firstName, string lastName, string login)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
        }        
    }
}

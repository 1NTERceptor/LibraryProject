using Library.Domain.Aggregates;
using MediatR;

namespace REST_API.Populate
{
    public interface IPersonFactory
    {
        Person CreatePerson(string firstName, string lastName, string cardNumber, string login);        
    }

    public class PersonFactory : IPersonFactory
    {
        public delegate Person PersonCreatorDelegate(string firstName, string lastName, string cardNumber, string login);
        private readonly PersonCreatorDelegate _createPerson;
        public PersonFactory(PersonCreatorDelegate createPerson)
        {
            _createPerson = createPerson;
        }

        public Person CreatePerson(string firstName, string lastName, string cardNumber, string login)
        {
            return _createPerson(firstName, lastName, cardNumber, login);
        }
    }
}

using Library.Domain.Aggregates;
using Library.Domain.Aggregates.Persons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Services
{
    public interface IPeople
    {
        Task<IEnumerable<Person>> GetPersons();
        Task<IEnumerable<GuestBook>> GetGuestBooks(int guestId);

        Task<Person> GetPersonById(int id);
        Task<Guest> CreateGuest(string firstName, string lastName, string guestCardNumber);

        Task<bool> EditPerson(int id, Person person);

        Task<bool> BoorowBook(Book book, int guestId);
    }
}

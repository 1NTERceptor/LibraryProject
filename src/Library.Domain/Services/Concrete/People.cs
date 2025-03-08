using Library.Domain.Aggregates;
using Library.Domain.Aggregates.Persons;
using Library.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Library.Domain.Services
{
    public class People : IPeople
    {
        private readonly IPersonRepository _repository;

        public People(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Person>> GetPersons()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<Worker>> GetWorkers()
        {
            var workers = await _repository.GetAllWorkersAsync();

            return workers;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repository.GetAllUsersAsync();
        }

        public async Task<IEnumerable<GuestBook>> GetGuestBooks(int guestId)
        {
            return await _repository.GetGuestBookByGuestIdAsync(guestId);
        }

        public async Task<Person> GetPersonById(int id)
        {
            var person = await _repository.GetByIdAsync(id);

            if (person == default)
                await Task.FromResult<Person>(null);      
            
            if(person is User guest)
                return await _repository.GetGuestByIdAsync(id);

            return person;
        }

        public async Task<User> CreateGuest(string firstName, string lastName, string guestCardNumber)
        {
            var guest = User.CreateUser(firstName, lastName, guestCardNumber, null);

            await _repository.AddAsync(guest);

            return guest;
        }

        public async Task<bool> BoorowBook(Book book, int guestId)
        {
            var guest = await _repository.GetGuestByIdAsync(guestId)
                ?? throw new ArgumentNullException($"Nie znaleziono użytkownika o Id  = ${guestId}");

            var guestBook = guest.BorrowBook(book);

            if (guestBook == null)
                return false;

            await _repository.UpdateAsync(guest);
            await _repository.UpdateAsync(guestBook);

            return true;
        }

        public async Task<bool> EditPerson(int id, Person editPerson)
        {
            var person = await _repository.GetByIdAsync(id);

            if (person == null)
                return false;

            editReflectionProperties(person, "FirstName", editPerson.FirstName);
            editReflectionProperties(person, "LastName", editPerson.LastName);
            editReflectionProperties(person, "Login", editPerson.Login);

            await _repository.UpdateAsync(person);

            return true;
        }

        private void editReflectionProperties(Person person, string property, object value)
        {
            Type objectType = person.GetType();

            var propertyInfo = objectType.GetProperty(property, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            if (propertyInfo != null && propertyInfo.CanWrite)
            {
                propertyInfo.SetValue(person, value, null);
            }
        }        
    }
}

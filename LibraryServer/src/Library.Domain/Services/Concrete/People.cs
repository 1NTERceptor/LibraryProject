using Library.Domain.Aggregates;
using Library.Domain.Aggregates.Persons;
using Library.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Library.Domain.Services
{
    public class People : IPeople
    {
        private readonly IPersonRepository _repository;
        private static People _instance;
        private static readonly object _lock = new object();

        //public static People GetInstance(DataContext context)
        //{
        //    if (_instance == null)
        //    {
        //        lock (_lock)
        //        {
        //            if (_instance == null)
        //            {
        //                _instance = new People(context);
        //            }
        //        }
        //    }
        //    return _instance;
        //}

        //private People(DataContext context)
        //{
        //    _context = context;
        //}

        public People(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Person>> GetPersons()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<GuestBook>> GetGuestBooks(int guestId)
        {
            return await _repository.GetGuestBookByGuestIdAsync(guestId);
        }

        public async Task<Person> GetPersonById(int id)
        {
            var person = await _repository.GetByIdAsync(id);

            if (person == default)
                Task.FromResult<Person>(null);      
            
            if(person is Guest guest)
                return await _repository.GetGuestByIdAsync(id);

            return person;
        }

        public async Task<Guest> CreateGuest(string firstName, string lastName, string guestCardNumber)
        {
            var guest = Guest.CreateGuest(firstName, lastName, guestCardNumber, null);

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

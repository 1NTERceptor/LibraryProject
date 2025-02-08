using Library.Domain.Aggregates;
using Library.Domain.Aggregates.Persons;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Library.Domain.Repository
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(int id);
        Task<Guest> GetGuestByIdAsync(int id);
        Task<IEnumerable<GuestBook>> GetGuestBookByGuestIdAsync(int id);
        Task<IEnumerable<Person>> GetAllAsync();
        Task AddAsync(Person person);
        Task UpdateAsync(Person person);
        Task UpdateAsync(GuestBook guestBook);
        Task DeleteAsync(int id);
        Task Commit();
    }

    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _context;

        public PersonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            return await _context.Guests
                .Include(g => g.BorrowedBooks)
                //.ThenInclude(bg => bg.Book)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<IEnumerable<GuestBook>> GetGuestBookByGuestIdAsync(int id)
        {
            return _context.Guests.FirstOrDefault(g => g.Id == id).BorrowedBooks;
        }

        public async Task AddAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            if (person is Guest guest)
            {
                _context.Guests.Update(guest);
            }
            else
            {
                _context.Persons.Update(person);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var person = await GetByIdAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GuestBook guestBook)
        {
            _context.GuestBooks.Update(guestBook);
            await _context.SaveChangesAsync();
        }
    }
}

using Abstracts.Repository;
using Library.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Domain.Repository
{
    public interface IPersonRepository 
    {
        Task<Person> GetByIdAsync(int id);
        Task<Person> GetUserByIdAsync(int id);

        Task<IEnumerable<Worker>> GetAllWorkersAsync();

        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddAsync(User person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(int id);
        Task Commit();
    }

    public class PersonRepository : IRepository<Person>, IPersonRepository
    {
        private readonly IDataContext _context;

        public PersonRepository(IDataContext context)
        {
            _context = context;
        }

        public Task<IQueryable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(User person)
        {
            _context.Users.Add(person);
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<Person> GetUserByIdAsync(int id)
        {
            return await _context.Users.Where(p => p.Key == id).FirstOrDefaultAsync();
        }        

        public async Task UpdateAsync(Person person)
        {
            if (person is User guest)
            {
                _context.Users.Update(guest);
            }
            else if(person is Worker worker)
            {
                _context.Workers.Update(worker);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var person = await GetByIdAsync(id);

            if (person == null)
                return;

            if (person is User guest)
            {
                _context.Users.Remove(guest);
            }
            else if (person is Worker worker)
            {
                _context.Workers.Remove(worker);
            }
        }

        public async Task<IEnumerable<Worker>> GetAllWorkersAsync()
        {
            var workers = await _context.Workers.ToListAsync();

            return workers;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task Commit()
        {
            throw new NotImplementedException();
        }

        Task<IQueryable<Person>> IRepository<Person>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}

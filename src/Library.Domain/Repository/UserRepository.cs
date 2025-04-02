using Abstracts.Repository;
using Library.Domain.Aggregates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Library.Domain.Repository
{
    public interface IUserRepository : IRepository<User>
    {    
        Task UpdateAsync(User person);

        Task DeleteAsync(Guid id);
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbSet<User> _users;

        public UserRepository(IDataContext context, IPublisher publisher) : base(context, publisher)
        {
            _users = _context.Set<User>();
        }

        public async Task UpdateAsync(User user)
        {
            _users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                _users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}

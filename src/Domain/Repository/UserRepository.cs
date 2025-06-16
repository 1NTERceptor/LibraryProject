using Domain.Aggregates.Persons;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Repository;
using System;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IUserRepository : IRepository<User>
    {    
        Task UpdateAsync(User person);
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
    }
}

using Application.Contracts;
using Domain.Aggregates.Persons;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Repository;

namespace Infrastructure.Database.Repository
{
    

    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbSet<User> _users;

        public UserRepository(ILibraryContext context, IPublisher publisher) : base(context, publisher)
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

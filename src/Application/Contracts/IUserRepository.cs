using Domain.Aggregates.Persons;
using SharedKernel.Repository;

namespace Application.Contracts;

public interface IUserRepository : IRepository<User>
{
    Task UpdateAsync(User person);
}

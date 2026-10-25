using Domain.Aggregates.Persons;
using SharedKernel.Repository;

namespace Application.Contracts;

public interface IWorkerRepository : IRepository<Worker>
{
    Task UpdateAsync(Worker worker);
}
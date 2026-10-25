using Application.Contracts;
using Domain.Aggregates.Persons;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Repository;

namespace Infrastructure.Database.Repository
{   
    public class WorkerRepository : Repository<Worker>, IWorkerRepository
    {
        private readonly DbSet<Worker> _workers;

        public WorkerRepository(ILibraryContext context, IPublisher publisher) : base(context, publisher)
        {
            _workers = _context.Set<Worker>();
        }

        public async Task UpdateAsync(Worker worker)
        {
            _workers.Update(worker);
            await _context.SaveChangesAsync();
        }
    }
}

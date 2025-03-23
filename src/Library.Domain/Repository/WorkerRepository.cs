using Abstracts.Repository;
using Library.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Library.Domain.Repository
{
    public interface IWorkerRepository : IRepository<Worker>
    {
        Task UpdateAsync(Worker worker);
        Task DeleteAsync(Guid id);
    }

    public class WorkerRepository : Repository<Worker>, IWorkerRepository
    {
        private readonly DbSet<Worker> _workers;

        public WorkerRepository(DataContext context) : base(context)
        {
            _workers = _context.Set<Worker>();
        }

        public async Task DeleteAsync(Guid id)
        {
            var worker = await GetByIdAsync(id);
            if (worker != null)
            {
                _workers.Remove(worker);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Worker worker)
        {
            _workers.Update(worker);
            await _context.SaveChangesAsync();
        }
    }
}

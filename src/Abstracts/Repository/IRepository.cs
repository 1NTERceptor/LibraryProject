using Abstracts.DDD;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Abstracts.Repository
{
    public interface IRepository<T> where T : AggregateRoot
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
    }

}

using Abstracts.DDD;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abstracts.Repository
{
    public interface IRepository<T> where T : AggregateRoot
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task Commit();
    }

    public class Repository<T> : IRepository<T> where T : AggregateRoot
    {
        protected readonly IDataContextBase _context;
        protected readonly IPublisher _publisher;

        public Repository(IDataContextBase context, IPublisher publisher)
        {
            _context = context;
            _publisher = publisher;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();

            var domainEvents = _context.ChangeTracker
                .Entries<AggregateRoot>()
                .SelectMany(e => e.Entity.GetDomainEvents())
                .ToList();

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent);
            }

            foreach (var entity in _context.ChangeTracker.Entries<AggregateRoot>())
            {
                entity.Entity.ClearDomainEvents();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}

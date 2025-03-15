using Library.Domain.Aggregates.Borrow;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Repository
{
    public interface IBorrowRepository
    {
        Task<Borrow> GetByIdAsync(int id);
        Task<IEnumerable<Borrow>> GetAllAsync();
        Task AddAsync(Borrow borrow);
        Task UpdateAsync(Borrow borrow);
        Task DeleteAsync(int id);
    }

    public class BorrowRepository : IBorrowRepository
    {
        private readonly DataContext _context;

        public BorrowRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Borrow> GetByIdAsync(int id)
        {
            return await _context.Borrows.FindAsync(id);
        }

        public async Task<IEnumerable<Borrow>> GetAllAsync()
        {
            return await _context.Borrows.ToListAsync();
        }

        public async Task<IEnumerable<Borrow>> GetAll()
        {
            return await _context.Borrows.ToListAsync();
        }

        public async Task AddAsync(Borrow borrow)
        {
            await _context.Borrows.AddAsync(borrow);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Borrow borrow)
        {
            _context.Borrows.Update(borrow);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var borrow = await GetByIdAsync(id);
            if (borrow != null)
            {
                _context.Borrows.Remove(borrow);
                await _context.SaveChangesAsync();
            }
        }
    }
}

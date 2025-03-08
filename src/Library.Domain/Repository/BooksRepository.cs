using Library.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Repository
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetAll();
        Task<IEnumerable<Book>> GetAllAsync();
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
    }

    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await GetByIdAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}

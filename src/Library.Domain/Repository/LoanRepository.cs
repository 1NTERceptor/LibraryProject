using Abstracts.Repository;
using Library.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Library.Domain.Repository
{
    public interface ILoanRepository : IRepository<Loan>
    {
        Task UpdateAsync(Loan loan);
        Task DeleteAsync(Guid id);
    }

    public class LoanRepository : Repository<Loan>, ILoanRepository
    {
        private readonly DbSet<Loan> _loans;

        public LoanRepository(DataContext context) : base(context)
        {
            _loans = _context.Set<Loan>();
        }

        public async Task UpdateAsync(Loan loan)
        {
            _loans.Update(loan);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var loan = await GetByIdAsync(id);
            if (loan != null)
            {
                _loans.Remove(loan);
                await _context.SaveChangesAsync();
            }
        }
    }
}

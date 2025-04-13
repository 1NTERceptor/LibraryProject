using Domain.Aggregates.Loan;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Repository;
using System;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ILoanRepository : IRepository<Loan>
    {
        Task UpdateAsync(Loan loan);
        Task DeleteAsync(Guid id);
    }

    public class LoanRepository : Repository<Loan>, ILoanRepository
    {
        private readonly DbSet<Loan> _loans;

        public LoanRepository(IDataContext context, IPublisher publisher) : base(context, publisher)
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

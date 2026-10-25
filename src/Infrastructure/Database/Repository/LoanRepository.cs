using Application.Contracts;
using Domain.Aggregates.Loans;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Repository;

namespace Infrastructure.Database.Repository
{   

    public class LoanRepository : Repository<Loan>, ILoanRepository
    {
        private readonly DbSet<Loan> _loans;

        public LoanRepository(ILibraryContext context, IPublisher publisher) : base(context, publisher)
        {
            _loans = _context.Set<Loan>();
        }

        public async Task UpdateAsync(Loan loan)
        {
            _loans.Update(loan);
            await _context.SaveChangesAsync();
        }
    }
}

using Domain.Aggregates.Loans;
using SharedKernel.Repository;

namespace Application.Contracts;

public interface ILoanRepository : IRepository<Loan>
{
    Task UpdateAsync(Loan loan);
}

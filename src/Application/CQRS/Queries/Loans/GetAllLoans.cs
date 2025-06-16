using Domain.Aggregates.Loans;
using MediatR;

namespace Application.CQRS.Queries.Loans
{
    public class GetAllLoans : IRequest<IEnumerable<Loan>>
    {
    }
}

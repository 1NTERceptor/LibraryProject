using Library.Messages.Models;
using MediatR;

namespace Application.CQRS.Queries.Loans
{
    public class GetAllLoans : IRequest<IEnumerable<LoanModel>>
    {
    }
}

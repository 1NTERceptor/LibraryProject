using Library.Messages.Models;
using MediatR;

namespace Library.Messages.Queries.Persons
{
    public class GetAllLoans : IRequest<IEnumerable<LoanModel>>
    {
    }
}

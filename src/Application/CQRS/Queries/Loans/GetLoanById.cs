using Library.Messages.Models;
using MediatR;

namespace Application.CQRS.Queries.Loans
{
    public class GetLoanById : IRequest<LoanModel>
    {
        public Guid Id { get; set; }
        public GetLoanById(Guid id) 
        {
            Id = id;
        }
    }
}

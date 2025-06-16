using Domain.Aggregates.Loans;
using MediatR;

namespace Application.CQRS.Queries.Loans
{
    public class GetLoanById : IRequest<Loan>
    {
        public Guid Id { get; set; }
        public GetLoanById(Guid id) 
        {
            Id = id;
        }
    }
}

using Library.Messages.Models;
using MediatR;

namespace Library.Messages.Queries.Loans
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

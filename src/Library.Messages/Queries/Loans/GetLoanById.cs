using Library.Messages.Models;
using MediatR;

namespace Library.Messages.Queries.Persons
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

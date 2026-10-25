using Application.Contracts;
using Application.CQRS.Queries.Loans;
using AutoMapper;
using Domain.Aggregates.Loans;
using MediatR;

namespace Application.CQRS.QueriesHandlers
{
    public class LoanQueriesHandlers :
        IRequestHandler<GetAllLoans, IEnumerable<Loan>>,
        IRequestHandler<GetLoanById, Loan>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public LoanQueriesHandlers(ILoanRepository loanRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Loan>> Handle(GetAllLoans request, CancellationToken cancellationToken)
        {
            var loans = await _loanRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Loan>>(loans);
        }

        public async Task<Loan> Handle(GetLoanById request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.Id);
            return _mapper.Map<Loan>(loan);
        }
    }
}

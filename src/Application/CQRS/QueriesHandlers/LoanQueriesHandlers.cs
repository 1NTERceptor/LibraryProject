using Application.CQRS.Queries.Loans;
using AutoMapper;
using Library.Domain.Repository;
using Library.Messages.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.QueriesHandlers
{
    public class LoanQueriesHandlers :
        IRequestHandler<GetAllLoans, IEnumerable<LoanModel>>,
        IRequestHandler<GetLoanById, LoanModel>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public LoanQueriesHandlers(ILoanRepository loanRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LoanModel>> Handle(GetAllLoans request, CancellationToken cancellationToken)
        {
            var loans = await _loanRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<LoanModel>>(loans);
        }

        public async Task<LoanModel> Handle(GetLoanById request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.Id);
            return _mapper.Map<LoanModel>(loan);
        }
    }
}

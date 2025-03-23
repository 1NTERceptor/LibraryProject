using AutoMapper;
using Library.Domain.Repository;
using Library.Messages.Models;
using Library.Messages.Queries.Persons;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Domain.CQRS.QueriesHandlers
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

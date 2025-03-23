using Library.Domain.Aggregates.Loan;
using Library.Domain.Repository;
using Library.Messages.Commands.Loans;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Domain.CQRS.CommandsHandlers
{
    public class LoanCommandsHandlers :        
        IRequestHandler<CreateLoanCommand, Guid>
    {
        private readonly ILoanRepository _loanRepository;

        public LoanCommandsHandlers(ILoanRepository loanRepository) 
        {
            _loanRepository = loanRepository;
        }        

        public async Task<Guid> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = new Loan(request.BookId, request.UserId, DateTime.Today, request.DateTo);

            await _loanRepository.AddAsync(loan);
            await _loanRepository.Commit();

            return loan.Key;
        }        
    }
}

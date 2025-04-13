using Domain.Repository;
using Library.Domain.Aggregates;
using Library.Messages.Commands.Loans;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.CQRS.CommandsHandlers
{
    public class LoanCommandsHandlers :        
        IRequestHandler<CreateLoanCommand, Guid>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDataContext _dataContext;

        public LoanCommandsHandlers(ILoanRepository loanRepository, IUserRepository userRepository, IDataContext dataContext)
        {
            _loanRepository = loanRepository;
            _userRepository = userRepository;
            _dataContext = dataContext;
        }

        public async Task<Guid> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var book = await _dataContext.Books.FindAsync(request.BookId);

            if(book == null)
                throw new ArgumentException($"Książka o Id = ${request.BookId} nie istnieje");

            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
                throw new ArgumentException($"Użytkownik o Id = ${request.UserId} nie istnieje");

            var loan = new Loan(request.BookId, request.UserId, DateTime.Today);

            await _loanRepository.AddAsync(loan);
            await _loanRepository.Commit();

            return loan.Key;
        }        
    }
}

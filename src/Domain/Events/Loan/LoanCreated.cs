using Abstracts.Event_Sourcing;
using System;

namespace Domain.Events.Loan
{
    public class LoanCreated : IDomainEvent
    {
        public Guid LoanId;
        public Guid BookId;
        public Guid UserId;

        public LoanCreated(Guid loanId, Guid bookId, Guid userId)
        {
            LoanId = loanId;
            BookId = bookId;
            UserId = userId;
        }
    }
}

using MediatR;

namespace Application.CQRS.Commands.Loans
{
    public class CreateLoanCommand : IRequest<Guid>
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateTo { get; set; }

        public CreateLoanCommand(Guid bookId, Guid userId, DateTime dateTo)
        {
            BookId = bookId;
            UserId = userId;
            DateTo = dateTo;
        }
    }
}

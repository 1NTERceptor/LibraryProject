using MediatR;

namespace Library.Domain.CQRS.Commands
{
    public class CreateBorrowBook : IRequest<bool>
    {
        public int BookId { get; set; }
        public int GuestId { get; set; }
        public CreateBorrowBook(int bookId, int guestId)
        {
            BookId = bookId;
            GuestId = guestId;
        }
    }
}

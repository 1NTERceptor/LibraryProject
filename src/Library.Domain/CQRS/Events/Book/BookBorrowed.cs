using Abstracts.Event_Sourcing;
using MediatR;

namespace Library.Domain.CQRS.Events.Book
{
    public class BookBorrowed : IDomainEvent, INotification
    {
        public int BookId { get; set; }
        public int GuestId { get; set; }

        public BookBorrowed(int bookId, int guestId)
        {
            BookId = bookId;
            GuestId = guestId;
        }
    }
}

using Abstracts.Event_Sourcing;
using MediatR;

namespace Library.Messages.Events.User
{
    public class GuestBorrowedBook : IDomainEvent, INotification
    {
        public int GuestId { get; set; }
        public int BookId { get; set; }

        public GuestBorrowedBook(int guestId, int bookId)
        {
            GuestId = guestId;
            BookId = bookId;
        }
    }
}

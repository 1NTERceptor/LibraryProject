using Abstracts.Event_Sourcing;
using MediatR;

namespace Domain.Events.User
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

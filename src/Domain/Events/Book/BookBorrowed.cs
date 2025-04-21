using Abstracts.Event_Sourcing;

namespace Domain.Events.Book
{
    public class BookBorrowed : IDomainEvent
    {
        public int BookId;
        public int GuestId;

        public BookBorrowed(int bookId, int guestId)
        {
            BookId = bookId;
            GuestId = guestId;
        }
    }
}

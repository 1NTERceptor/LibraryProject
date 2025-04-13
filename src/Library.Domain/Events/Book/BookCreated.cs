using Abstracts.Event_Sourcing;

namespace Domain.Events.Book
{
    public class BookCreated : IDomainEvent
    {
        public int BookId;

        public BookCreated(int bookId)
        {
            BookId = bookId;
        }
    }
}

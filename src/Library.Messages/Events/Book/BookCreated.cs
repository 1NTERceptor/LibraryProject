using Abstracts.Event_Sourcing;

namespace Library.Messages.Events.Book
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

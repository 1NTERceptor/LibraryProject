using Abstracts.Event_Sourcing;
using MediatR;

namespace Library.Messages.Events.Book
{
    public class BookCreated : IDomainEvent, INotification
    {
        public int BookId;

        public BookCreated(int bookId)
        {
            BookId = bookId;
        }
    }
}

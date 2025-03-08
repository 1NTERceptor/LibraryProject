using Library.Domain.Aggregates.Persons;
using Library.Domain.CQRS.Events.Person;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.Aggregates
{
    public class User : Person
    {
        public string GuestCardNumber { get; private set; }

        public string City { get; private set; }

        public virtual  ICollection<GuestBook> BorrowedBooks { get; set; } = new List<GuestBook>();

        public static User CreateUser(string firstName, string lastName, string guestCardNumber, string login)
        {
            return new User(firstName,  lastName, guestCardNumber, login);
        }

        public User() { }

        private User(string firstName, string lastName, string guestCardNumber, string login) : base(firstName, lastName, login) 
        {
            GuestCardNumber = guestCardNumber;

            AddDomainEvent(new GuestCreated(Id, firstName, lastName));
        }

        public GuestBook BorrowBook(Book book)
        {
            if (BorrowedBooks.Any(gb => gb.BookId == book.Id))
            {
                return null; 
            }

            var guestBook = new GuestBook
            {
                GuestId = this.Id,
                BookId = book.Id
            };

            BorrowedBooks.Add(guestBook);
            AddDomainEvent(new GuestBorrowedBook(Id, book.Id));

            return guestBook;
         }
    }
}

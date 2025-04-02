using Abstracts.DDD;
using Library.Messages.Events.Loan;
using System;

namespace Library.Domain.Aggregates
{
    public class Loan : AggregateRoot
    {
        /// <summary>
        /// Wypożyczona książka
        /// </summary>
        public Book Book { get; protected set; }

        public Guid BookId { get; protected set; }

        /// <summary>
        /// Wypożyczający użytkownik
        /// </summary>
        public User User { get; protected set; }

        public Guid UserId { get; protected set; }

        /// <summary>
        /// Data początku wypożyczenia
        /// </summary>
        public DateTime StartDate { get; protected set; }

        /// <summary>
        /// Data końca wypożyczenia
        /// </summary>
        public DateTime DueDate { get; protected set; }

        /// <summary>
        /// Data zwrotu książki
        /// </summary>
        public DateTime EndDate { get; protected set; }

        /// <summary>
        /// Ilość razy przedłużenia wypożyczenia
        /// </summary>
        public short ProlongTimes { get; set; }

        public Loan() { }

        public Loan(Guid bookId, Guid userId, DateTime fromDate)
        {
            BookId = bookId != Guid.Empty ? bookId : throw new ArgumentException($"Id książki jest nieprawidłowe = ${bookId}");
            UserId = userId != Guid.Empty ? userId : throw new ArgumentException($"Id użytkownika jest nieprawidłowe = ${userId}"); ;
            StartDate = fromDate != default ? fromDate : throw new ArgumentException($"Data wypożyczenia książki jest nieprawidłowa = ${fromDate}");
            DueDate = fromDate.AddDays(30);

            AddDomainEvent(new LoanCreated(this.Key, bookId, userId));
        }

        public void Return()
        {
            EndDate = DateTime.Today;
            User = null;
            Book = null;
        }
        
        public void Prolong()
        {
            if(ProlongTimes>2)
                throw new ArgumentException("Nie można przedłużyć książki więcej niż 3 razy");

            ProlongTimes++;
            EndDate = DueDate.AddDays(30);
        }
    }
}

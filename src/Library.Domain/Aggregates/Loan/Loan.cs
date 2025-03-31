using Abstracts.DDD;
using Library.Messages.Events.Loan;
using MediatR;
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
        public DateTime DateFrom { get; protected set; }

        /// <summary>
        /// Data końca wypożyczenia
        /// </summary>
        public DateTime DueDate { get; protected set; }

        /// <summary>
        /// Data zwrotu książki
        /// </summary>
        public DateTime DateTo { get; protected set; }

        /// <summary>
        /// Ilość razy przedłużenia wypożyczenia
        /// </summary>
        public short ProlongTimes { get; set; }

        public Loan() { }

        public Loan(Guid bookId, Guid userId, DateTime dateFrom)
        {
            BookId = bookId != Guid.Empty ? bookId : throw new ArgumentException($"Id książki jest nieprawidłowe = ${bookId}");
            UserId = userId != Guid.Empty ? userId : throw new ArgumentException($"Id użytkownika jest nieprawidłowe = ${userId}"); ;
            DateFrom = dateFrom != default ? dateFrom : throw new ArgumentException($"Data wypożyczenia książki jest nieprawidłowa = ${dateFrom}");
            DueDate = dateFrom.AddDays(30);

            AddDomainEvent(new LoanCreated(this.Key, bookId, userId));
        }

        public void Return()
        {
            DateTo = DateTime.Today;
            User = null;
            Book = null;
        }
        
        public void Prolong()
        {
            if(ProlongTimes>2)
                throw new ArgumentException("Nie można przedłużyć książki więcej niż 3 razy");

            ProlongTimes++;
            DateTo = DueDate.AddDays(30);
        }
    }
}

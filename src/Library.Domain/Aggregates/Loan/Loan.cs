using Abstracts.DDD;
using System;

namespace Library.Domain.Aggregates.Loan
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
        public DateTime DateTo { get; protected set; }
        

        public Loan(Guid bookId, Guid userId, DateTime dateFrom, DateTime dateTo) 
        {
            Key = Guid.NewGuid();
            BookId = bookId;
            UserId = userId;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}

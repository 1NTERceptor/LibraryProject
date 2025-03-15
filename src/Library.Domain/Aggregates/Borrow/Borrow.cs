using Abstracts.DDD;
using System;

namespace Library.Domain.Aggregates.Borrow
{
    public class Borrow : AggregateRoot
    {
        /// <summary>
        /// Id wypożyczenia
        /// </summary>
        public int BookId { get; protected set; }

        /// <summary>
        /// Id użytkownika
        /// </summary>
        public int UserId { get; protected set; }

        /// <summary>
        /// Data początku wypożyczenia
        /// </summary>
        public DateTime DateFrom { get; protected set; }

        /// <summary>
        /// Data końca wypożyczenia
        /// </summary>
        public DateTime DateTo { get; protected set; }

        public Borrow(int bookId, int userId, DateTime dateFrom, DateTime dateTo)
        {
            BookId = bookId;
            UserId = userId;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}

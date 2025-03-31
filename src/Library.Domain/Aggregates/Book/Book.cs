using Abstracts.DDD;
using MediatR;
using System;

namespace Library.Domain.Aggregates
{
    public class Book : AggregateRoot
    {
        /// <summary>
        /// Tytu³
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// Autor
        /// </summary>
        public string Author { get; protected set; }

        /// <summary>
        /// Data wydania ksi¹zki
        /// </summary>
        public DateTime ReleaseDate { get; protected set; }

        /// <summary>
        /// Krótki opis ksi¹¿ki
        /// </summary>
        public string Description { get; protected set; }

        /// <summary>
        /// Czy jest to seria ksi¹¿ek
        /// </summary>
        public bool IsSeries { get; protected set; }

        /// <summary>
        /// Poprzednia czêœæ ksi¹¿ki
        /// </summary>
        public Book PreviousPartOfSeries { get; protected set; }

        /// <summary>
        /// Wypo¿yczenie ksi¹zki
        /// </summary>
        public Loan Loan { get; protected set; }

        public Book() { }

        public Book(string title, string author, DateTime releaseDate, string description, bool isSeries = false)
        {
            Title = !String.IsNullOrEmpty(title) ? title : throw new ArgumentException($"Tytu³ ksi¹¿ki jest nieprawid³owy = ${title}");
            Author = !String.IsNullOrEmpty(author) ? author : throw new ArgumentException($"Autor ksi¹¿ki jest nieprawid³owy = ${author}");
            ReleaseDate = releaseDate != default ? releaseDate : throw new ArgumentException($"Data wydania ksi¹¿ki jest nieprawid³owa = ${releaseDate}");
            Description = description;
            IsSeries = isSeries;
        }

        public void MakeSeries(Book previousPartOfSeries)
        {
            IsSeries = true;
            PreviousPartOfSeries = previousPartOfSeries;
            PreviousPartOfSeries.IsSeries = true;
        }

        public void ChangeDescription(string newDescription)
        {
            Description = newDescription;
        }

        public void Borrow(Loan loan)
        {
            Loan = loan;
        }

        public void Return()
        {
            Loan = null;
        }
    }
}

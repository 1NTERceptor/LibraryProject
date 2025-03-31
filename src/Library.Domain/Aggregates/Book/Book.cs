using Abstracts.DDD;
using MediatR;
using System;

namespace Library.Domain.Aggregates
{
    public class Book : AggregateRoot
    {
        /// <summary>
        /// Tytu�
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// Autor
        /// </summary>
        public string Author { get; protected set; }

        /// <summary>
        /// Data wydania ksi�zki
        /// </summary>
        public DateTime ReleaseDate { get; protected set; }

        /// <summary>
        /// Kr�tki opis ksi��ki
        /// </summary>
        public string Description { get; protected set; }

        /// <summary>
        /// Czy jest to seria ksi��ek
        /// </summary>
        public bool IsSeries { get; protected set; }

        /// <summary>
        /// Poprzednia cz�� ksi��ki
        /// </summary>
        public Book PreviousPartOfSeries { get; protected set; }

        /// <summary>
        /// Wypo�yczenie ksi�zki
        /// </summary>
        public Loan Loan { get; protected set; }

        public Book() { }

        public Book(string title, string author, DateTime releaseDate, string description, bool isSeries = false)
        {
            Title = !String.IsNullOrEmpty(title) ? title : throw new ArgumentException($"Tytu� ksi��ki jest nieprawid�owy = ${title}");
            Author = !String.IsNullOrEmpty(author) ? author : throw new ArgumentException($"Autor ksi��ki jest nieprawid�owy = ${author}");
            ReleaseDate = releaseDate != default ? releaseDate : throw new ArgumentException($"Data wydania ksi��ki jest nieprawid�owa = ${releaseDate}");
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

using Abstracts.DDD;
using Library.Domain.CQRS.Events.Book;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Aggregates
{
    public class Book : AggregateRoot
    {
        /// <summary>
        /// Tytu�
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Autor
        /// </summary>
        [Required]
        public string Author { get; set; }

        /// <summary>
        /// Data wydania ksi�zki
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Kr�tki opis ksi��ki
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Czy jest to seria ksi��ek
        /// </summary>
        public bool IsSeries { get; set; }

        /// <summary>
        /// Poprzednia cz�� ksi��ki
        /// </summary>
        [ForeignKey("PreviousPartOfSeriesId")]
        public Book PreviousPartOfSeries { get; set; }

        /// <summary>
        /// Czy ksi��ka wypo�yczona
        /// </summary>
        public bool IsBorrowed { get; private set; }

        public Book() { }

        public Book(string title, string author, DateTime releaseDate, string description, bool isSeries = false)
        {
            Title = title;
            Author = author;
            ReleaseDate = releaseDate;
            Description = description;
            IsSeries = isSeries;

            AddDomainEvent(new BookCreated(Id));
        }

        public void MakeSeries(Book previousPartOfSeries)
        {
            IsSeries = true;
            PreviousPartOfSeries = previousPartOfSeries;
            PreviousPartOfSeries.IsSeries = true;
        }

        /// <summary>
        /// Wypo�yczenie ksi�zki
        /// </summary>
        /// <returns></returns>
        public bool Borrow(int guestId)
        {
            if (IsBorrowed)
                return false;

            IsBorrowed = true;

            AddDomainEvent(new BookBorrowed(Id, guestId));

            return true;            
        }
    }
}

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
        /// Tytu³
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Autor
        /// </summary>
        [Required]
        public string Author { get; set; }

        /// <summary>
        /// Data wydania ksi¹zki
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Krótki opis ksi¹¿ki
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Czy jest to seria ksi¹¿ek
        /// </summary>
        public bool IsSeries { get; set; }

        /// <summary>
        /// Poprzednia czêœæ ksi¹¿ki
        /// </summary>
        [ForeignKey("PreviousPartOfSeriesId")]
        public Book PreviousPartOfSeries { get; set; }

        /// <summary>
        /// Czy ksi¹¿ka wypo¿yczona
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
        /// Wypo¿yczenie ksi¹zki
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

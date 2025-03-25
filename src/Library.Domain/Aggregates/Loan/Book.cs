using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Aggregates.Loan
{
    public class Book 
    {
        /// <summary>
        /// Id ksi��ki
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Tytu�
        /// </summary>
        [Required]
        public string Title { get; private set; }

        /// <summary>
        /// Autor
        /// </summary>
        [Required]
        public string Author { get; private set; }

        /// <summary>
        /// Data wydania ksi�zki
        /// </summary>
        public DateTime ReleaseDate { get; private set; }

        /// <summary>
        /// Kr�tki opis ksi��ki
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Czy jest to seria ksi��ek
        /// </summary>
        public bool IsSeries { get; private set; }

        /// <summary>
        /// Poprzednia cz�� ksi��ki
        /// </summary>
        [ForeignKey("PreviousPartOfSeriesId")]
        public Book PreviousPartOfSeries { get; private set; }

        /// <summary>
        /// Wypo�yczenie ksi�zki
        /// </summary>
        public Loan Loan { get; private set; }

        public Guid LoanId { get; private set; }

        public Book() { }

        public Book(string title, string author, DateTime releaseDate, string description, bool isSeries = false)
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            ReleaseDate = releaseDate;
            Description = description;
            IsSeries = isSeries;
        }

        public void MakeSeries(Book previousPartOfSeries)
        {
            IsSeries = true;
            PreviousPartOfSeries = previousPartOfSeries;
            PreviousPartOfSeries.IsSeries = true;
        }
    }
}

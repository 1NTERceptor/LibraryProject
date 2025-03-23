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
        public Guid Id { get; set; }

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

        public Book() { }

        public Book(string title, string author, DateTime releaseDate, string description, bool isSeries = false)
        {
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

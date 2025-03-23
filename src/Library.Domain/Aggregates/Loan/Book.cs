using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Aggregates.Loan
{
    public class Book 
    {
        /// <summary>
        /// Id ksi¹¿ki
        /// </summary>
        public Guid Id { get; set; }

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

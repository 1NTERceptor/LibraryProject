using System;

namespace Library.Domain.Aggregates.Builders
{
    public class BookBuilder
    {
        public string _title = "brak tytułu";
        public string _autor = "nieznany";
        public DateTime _releaseDate = new DateTime();
        public string _description = "brak opisu";
        public Book _previousPartOfSeries = null;

        public BookBuilder SetTitle(string title) { _title = title; return this; }

        public BookBuilder SetAuthor(string author) { _autor = author; return this; }

        public BookBuilder SetReleaseDate(DateTime year){ _releaseDate = year; return this; }

        public BookBuilder SetDescription(string description) { _description = description; return this; }

        public BookBuilder SetPreviousBookPart(Book previousPartOfSeries) { _previousPartOfSeries = previousPartOfSeries; return this; }

        public static BookBuilder Given() => new BookBuilder();

        public Book Build()
        {
            var book = new Book(_title, _autor, _releaseDate, _description);

            if (_previousPartOfSeries != null)
                book.MakeSeries(_previousPartOfSeries);

            return book;
        }
    }
}

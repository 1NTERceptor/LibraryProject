namespace Library.Messages.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public bool IsSeries { get; set; }

        public bool IsBorrowed { get; private set; }

        public BookModel() { }

        public BookModel(string title, string author, DateTime releaseDate, string description, bool isSeries = false)
        {
            Title = title;
            Author = author;
            ReleaseDate = releaseDate;
            Description = description;
            IsSeries = isSeries;
        }
    }
}

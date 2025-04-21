namespace Library.Messages.Models
{
    public class BookModel
    {
        public Guid Key { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public bool IsSeries { get; set; }

        public bool IsBorrowed { get; private set; }

        public BookModel() { }
    }
}

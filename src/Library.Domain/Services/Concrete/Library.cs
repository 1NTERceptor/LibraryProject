using Library.Domain.Aggregates;
using Library.Domain.Aggregates.Builders;
using Library.Domain.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Services
{
    public class Library : ILibrary, IDisposable
    {
        private readonly IBookRepository _repository;
        private bool _disposed = false;
        public delegate bool BookFilter(Book book, dynamic id);
        StreamReader _reader = null;

        public Library(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Book> GetById(int id)
        {
            var books = await _repository.GetAllAsync();
            BookFilter filter = FilterById;
            return books.FirstOrDefault(b => filter(b, id) == true);
        }

        public async Task<Book> GetByIdAndTitle(int id, string title)
        {
            var books = await _repository.GetAllAsync();
            BookFilter filter = FilterById;
            return books.FirstOrDefault(b => filter(b, id) == true && FilterByTitle(b, title) == true);
        }

        public async Task<Book> GetByTitle(string title)
        {
            var books = await _repository.GetAllAsync();
            return books.FirstOrDefault(b => FilterByDynamic(b, title) == true);
        }

        public async Task<IEnumerable<Book>> GetByDate(DateTime releaseDate)
        {
            var books = await _repository.GetAllAsync();
            return books.Where(b => FilterByDynamic(b, releaseDate) == true).ToList();
        }

        public async IAsyncEnumerable<Book> GetBooksSeries(string author)
        {
            foreach(var book in await _repository.GetAll())
            {
                if(book.Author.ToLower() == author.ToLower())
                    yield return book;
            }            
        }

        public async Task<bool> AddBook(Book book)
        {
            if ((await _repository.GetAll()).Any(b => b.Title.ToLower() == book.Title.ToLower()))
                return false;

            await _repository.AddAsync(book);

            return true;
        }

        public async Task<bool> Remove(int id)
        {
            var book = await _repository.GetByIdAsync(id);

            if (book == null)
                return false;

            await _repository.DeleteAsync(id);

            return true;
        }

        public async Task<bool> UpdateBook(Book bookToCorrect)
        {
            var book = await _repository.GetByIdAsync(bookToCorrect.Id);

            if (book == null)
                return false;

            book.Title = bookToCorrect.Title;
            book.Author = bookToCorrect.Author;
            book.ReleaseDate = bookToCorrect.ReleaseDate;
            book.Description = bookToCorrect.Description;
            book.IsSeries = bookToCorrect.IsSeries;
            //book.PreviousPartOfSeries = bookToCorrect.PreviousPartOfSeries;

            return true;
        }

        public async Task<Book> GuestBorrowBook(int id, int guestId)
        {
            var book = await _repository.GetByIdAsync(id)
                ?? throw new ArgumentNullException($"Nie istnieje ksiązka o id = ${id}");

            var results = book.Borrow(guestId);

            await _repository.UpdateAsync(book);

            return book;
        }

        public bool FilterById(Book book, dynamic id)
        {
            return book.Id == id;
        }

        public bool FilterByTitle(Book book, dynamic title)
        {
            return book.Title.Equals(title, StringComparison.OrdinalIgnoreCase);
        }

        public bool FilterByReleaseDate(Book book, dynamic releaseDate)
        {
            return book.ReleaseDate.Date.Equals(releaseDate.Date);
        }

        public bool FilterByDynamic(Book book, dynamic variable)
        {
            if (variable is int id)
            {
                return book.Id.Equals(id);
            }
            else if (variable is string title)
            {
                return book.Title.Equals(title, StringComparison.OrdinalIgnoreCase);
            }
            else if (variable is DateTime releaseDate)
            {
                return book.ReleaseDate.Date.Equals(releaseDate.Date);
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Book>> GetFromFile(string filePath)
        {
            List<Book> books = new List<Book>();
            try
            {
                var lines = new List<string>();

                _reader = new StreamReader(filePath, Encoding.UTF8);

                string line;
                while ((line = await _reader.ReadLineAsync()) != null)
                {
                    lines.Add(line);
                }

                foreach (var row in lines)
                {
                    var bookData = row.Split(',');

                    if (bookData.Length == 4)
                    {
                        var book = BookBuilder.Given()
                            .SetTitle(bookData[0].Trim())
                            .SetAuthor(bookData[1].Trim())
                            .SetReleaseDate(DateTime.Parse(bookData[2].Trim()))
                            .SetDescription(bookData[3].Trim())
                            .Build();

                        await _repository.AddAsync(book);
                        books.Add(book);
                    }
                }

                return books;
            }
            catch (Exception ex)
            {
                throw new Exception($"Wystąpił błąd podczas zczytywania książek z pliku: {ex.Message}");
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if(_reader != null)
                    {
                        _reader.Dispose();
                    }
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }                

        ~Library()
        {
            Dispose(disposing: false);
        }
    }
}

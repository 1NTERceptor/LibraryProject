using Application.Contracts;
using Domain.Aggregates.Books;
using System.Text;

namespace Infrastructure.Services
{
    public interface IFileReader
    {
        Task<IEnumerable<Book>> GetFromFile(string filePath);
    }

    public class FileReader : IFileReader
    {
        private readonly ILibraryContext _context;
        private StreamReader _reader = null;

        public FileReader(ILibraryContext context) 
        {
            _context = context;
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
                        var book = new Book(
                            bookData[0].Trim(),
                            bookData[1].Trim(),
                            DateTime.Parse(bookData[2].Trim()),
                            bookData[3].Trim()); 

                        await _context.Books.AddAsync(book);
                        await _context.SaveChangesAsync();
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
    }
}

using Library.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Services
{
    public interface ILibrary
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<bool> AddBook(Book book);
        Task<Book> GetById(int id);
        Task<Book> GetByTitle(string title);
        Task<IEnumerable<Book>> GetByDate(DateTime releaseDate);
        Task<IEnumerable<Book>> GetFromFile(string filePath);
        Task<bool> Remove(int id);
        Task<bool> UpdateBook(Book bookToCorrect);
        IAsyncEnumerable<Book> GetBooksSeries(string author);
        bool FilterByDynamic(Book book, dynamic variable);
        Task<Book> GuestBorrowBook(int id, int guestId);
    }
}

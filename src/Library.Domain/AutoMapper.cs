using AutoMapper;
using Domain.Aggregates.Book;
using Domain.Aggregates.Loan;
using Domain.Aggregates.Persons;
using Library.Messages.Models;

namespace Domain
{
    public class LibraryMapper : Profile
    {
        public LibraryMapper() 
        {
            CreateMap<Worker, WorkerModel>();
            CreateMap<Book, BookModel>();
            CreateMap<User, UserModel>();
            CreateMap<Loan, LoanModel>();
        }
    }
}

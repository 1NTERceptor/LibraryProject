using AutoMapper;
using Library.Domain.Aggregates;
using Library.Messages.Models;

namespace Library.Domain
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

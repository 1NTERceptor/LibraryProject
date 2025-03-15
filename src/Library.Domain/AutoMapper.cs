using AutoMapper;
using Library.Domain.Aggregates;
using Library.Domain.Aggregates.Borrow;
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
        }
    }
}

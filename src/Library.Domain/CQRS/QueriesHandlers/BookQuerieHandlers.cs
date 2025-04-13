using AutoMapper;
using Domain;
using Library.Messages.Models;
using Library.Messages.Queries.Books;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.CQRS.QueriesHandlers
{
    public class BookQuerieHandlers : IRequestHandler<GetAllBooks, IEnumerable<BookModel>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public BookQuerieHandlers(IDataContext dataCotext, IMapper mapper) 
        {
            _dataContext = dataCotext;
        }

        public async Task<IEnumerable<BookModel>> Handle(GetAllBooks request, CancellationToken cancellationToken)
        {
            var books = await _dataContext.Books.ToListAsync();
            return _mapper.Map<IEnumerable<BookModel>>(books);
        }
    }
}

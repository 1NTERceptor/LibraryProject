using Application.CQRS.Queries.Books;
using AutoMapper;
using Library.Messages.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.QueriesHandlers
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

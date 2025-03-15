using AutoMapper;
using Library.Domain.Aggregates;
using Library.Domain.CQRS.Queries;
using Library.Messages.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Domain.CQRS.QueriesHandlers
{
    public class BookQueryHandlers : IRequestHandler<GetAllBooks, IEnumerable<BookModel>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public BookQueryHandlers(IDataContext dataCotext, IMapper mapper) 
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

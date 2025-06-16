using Application.CQRS.Queries.Books;
using AutoMapper;
using Domain;
using Domain.Aggregates.Books;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.QueriesHandlers
{
    public class BookQuerieHandlers : IRequestHandler<GetAllBooks, IEnumerable<Book>>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public BookQuerieHandlers(IDataContext dataCotext, IMapper mapper) 
        {
            _dataContext = dataCotext;
        }

        public async Task<IEnumerable<Book>> Handle(GetAllBooks request, CancellationToken cancellationToken)
        {
            return await _dataContext.Books.ToListAsync();            
        }
    }
}

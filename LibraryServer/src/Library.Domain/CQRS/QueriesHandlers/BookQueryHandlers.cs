using Library.Domain.Aggregates;
using Library.Domain.CQRS.Queries;
using Library.Domain.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Domain.CQRS.QueriesHandlers
{
    public class BookQueryHandlers : IRequestHandler<GetAllBooks, IEnumerable<Book>>
    {
        private readonly ILibrary _library;

        public BookQueryHandlers(ILibrary library) 
        {
            _library = library;
        }

        public async Task<IEnumerable<Book>> Handle(GetAllBooks request, CancellationToken cancellationToken)
        {
            return await _library.GetBooks();
        }
    }
}

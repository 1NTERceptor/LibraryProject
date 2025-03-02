using Library.Domain.Aggregates;
using MediatR;
using System.Collections.Generic;

namespace Library.Domain.CQRS.Queries
{
    public class GetAllBooks : IRequest<IEnumerable<Book>>
    {
    }
}

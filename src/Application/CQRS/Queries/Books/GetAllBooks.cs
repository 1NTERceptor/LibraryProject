using Domain.Aggregates.Books;
using MediatR;

namespace Application.CQRS.Queries.Books
{
    public class GetAllBooks : IRequest<IEnumerable<Book>>
    {
    }
}

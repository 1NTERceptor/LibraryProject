using Library.Messages.Models;
using MediatR;

namespace Application.CQRS.Queries.Books
{
    public class GetAllBooks : IRequest<IEnumerable<BookModel>>
    {
    }
}

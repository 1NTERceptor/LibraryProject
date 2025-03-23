using Library.Messages.Models;
using MediatR;

namespace Library.Messages.Queries.Books
{
    public class GetAllBooks : IRequest<IEnumerable<BookModel>>
    {
    }
}

using Library.Messages.Models;
using MediatR;

namespace Library.Domain.CQRS.Queries
{
    public class GetAllBooks : IRequest<IEnumerable<BookModel>>
    {
    }
}

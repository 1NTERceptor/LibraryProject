using Library.Messages.Models;
using MediatR;

namespace Library.Domain.CQRS.Queries
{
    public class GetAllUsers : IRequest<IEnumerable<UserModel>>
    {
    }
}

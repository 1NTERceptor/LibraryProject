using Library.Messages.Models;
using MediatR;

namespace Application.CQRS.Queries.Persons
{
    public class GetAllUsers : IRequest<IEnumerable<UserModel>>
    {
    }
}

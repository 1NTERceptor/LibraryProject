using Library.Messages.Models;
using MediatR;

namespace Library.Messages.Queries.Persons
{
    public class GetAllUsers : IRequest<IEnumerable<UserModel>>
    {
    }
}

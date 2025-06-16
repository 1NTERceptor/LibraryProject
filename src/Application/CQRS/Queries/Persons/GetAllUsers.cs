using Domain.Aggregates.Persons;
using MediatR;

namespace Application.CQRS.Queries.Persons
{
    public class GetAllUsers : IRequest<IEnumerable<User>>
    {
    }
}

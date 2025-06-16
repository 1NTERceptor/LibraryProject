using Domain.Aggregates.Persons;
using MediatR;

namespace Application.CQRS.Queries.Persons
{
    public class GetAllWorkers : IRequest<IEnumerable<Worker>>
    {
    }
}

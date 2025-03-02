using Library.Domain.Aggregates;
using MediatR;
using System.Collections.Generic;

namespace Library.Domain.CQRS.Queries
{
    public class GetAllWorkers : IRequest<IEnumerable<Worker>>
    {
    }
}

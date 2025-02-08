using Library.Domain.Aggregates;
using MediatR;
using System.Collections.Generic;

namespace Library.Domain.CQRS.Queries
{
    public class GetAllPersons : IRequest<IEnumerable<Person>>
    {
    }
}

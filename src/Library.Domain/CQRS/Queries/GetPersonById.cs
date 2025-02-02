using Library.Domain.Aggregates;
using MediatR;

namespace Library.Domain.CQRS.Queries
{
    public class GetPersonById : IRequest<Person>
    {
        public int PersonId { get; set; }

        public GetPersonById(int personId)
        {
            PersonId = personId;
        }
    }
}

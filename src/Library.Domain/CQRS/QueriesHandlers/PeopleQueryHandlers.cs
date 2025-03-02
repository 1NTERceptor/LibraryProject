using Library.Domain.Aggregates;
using Library.Domain.Aggregates.Persons;
using Library.Domain.CQRS.Queries;
using Library.Domain.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace REST_API.QueriesHandlers
{
    public class PeopleQueryHandlers : 
        IRequestHandler<GetAllPersons, IEnumerable<Person>>,
        IRequestHandler<GetPersonById, Person>,
        IRequestHandler<GetGuestBorrowedBooksByGuestId, IEnumerable<GuestBook>>,
        IRequestHandler<GetAllWorkers, IEnumerable<Worker>>,
        IRequestHandler<GetAllUsers, IEnumerable<User>>
    {
        private readonly IPeople _persons;

        public PeopleQueryHandlers(IPeople persons) 
        {
            _persons = persons;
        }

        public async Task<IEnumerable<Person>> Handle(GetAllPersons request, CancellationToken cancellationToken)
        {
            return await _persons.GetPersons();
        }

        public async Task<Person> Handle(GetPersonById request, CancellationToken cancellationToken)
        {
            return await _persons.GetPersonById(request.PersonId);
        }

        public async Task<IEnumerable<GuestBook>> Handle(GetGuestBorrowedBooksByGuestId request, CancellationToken cancellationToken)
        {
            return await _persons.GetGuestBooks(request.GuestId);
        }

        public async Task<IEnumerable<Worker>> Handle(GetAllWorkers request, CancellationToken cancellationToken)
        {
            var workers = await _persons.GetWorkers();
            return workers;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            var users = await _persons.GetUsers();
            return users;
        }
    }
}

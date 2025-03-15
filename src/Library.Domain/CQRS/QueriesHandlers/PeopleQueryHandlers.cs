using AutoMapper;
using Library.Domain.Aggregates;
using Library.Domain.CQRS.Queries;
using Library.Domain.Repository;
using Library.Messages.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace REST_API.QueriesHandlers
{
    public class PeopleQueryHandlers : 
        IRequestHandler<GetAllWorkers, IEnumerable<WorkerModel>>,
        IRequestHandler<GetAllUsers, IEnumerable<UserModel>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PeopleQueryHandlers(IPersonRepository personRepository, IMapper mapper) 
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorkerModel>> Handle(GetAllWorkers request, CancellationToken cancellationToken)
        {
            var workers = await _personRepository.GetAllWorkersAsync();
            return _mapper.Map<IEnumerable<WorkerModel>>(workers);
        }

        public async Task<IEnumerable<UserModel>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            var users = await _personRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserModel>>(users);
        }
    }
}

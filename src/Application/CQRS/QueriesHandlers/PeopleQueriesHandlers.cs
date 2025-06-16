using Application.CQRS.Queries.Persons;
using AutoMapper;
using Domain.Aggregates.Persons;
using Domain.Repository;
using MediatR;

namespace Application.CQRS.QueriesHandlers
{
    public class PeopleQueriesHandlers : 
        IRequestHandler<GetAllWorkers, IEnumerable<Worker>>,
        IRequestHandler<GetAllUsers, IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IWorkerRepository _workerRepository;
        private readonly IMapper _mapper;

        public PeopleQueriesHandlers(IUserRepository userRepository, IWorkerRepository workerRepository, IMapper mapper) 
        {
            _userRepository = userRepository;
            _workerRepository = workerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Worker>> Handle(GetAllWorkers request, CancellationToken cancellationToken)
        {
            var workers = await _workerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Worker>>(workers);
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<User>>(users);
        }
    }
}

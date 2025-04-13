using AutoMapper;
using Domain.Repository;
using Library.Messages.Models;
using Library.Messages.Queries.Persons;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.CQRS.QueriesHandlers
{
    public class PeopleQueriesHandlers : 
        IRequestHandler<GetAllWorkers, IEnumerable<WorkerModel>>,
        IRequestHandler<GetAllUsers, IEnumerable<UserModel>>
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

        public async Task<IEnumerable<WorkerModel>> Handle(GetAllWorkers request, CancellationToken cancellationToken)
        {
            var workers = await _workerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<WorkerModel>>(workers);
        }

        public async Task<IEnumerable<UserModel>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserModel>>(users);
        }
    }
}

using Application.Contracts;
using Application.CQRS.Commands.Persons;
using Application.CQRS.Queries.Persons;
using AutoMapper;
using Domain.Aggregates.Persons;
using Library.Messages.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using REST_API.Populate;
using static REST_API.Populate.PersonFactory;

namespace REST_API.Controllers
{
    [Route("api/v1/[Area]")]
    [Area("persons")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        private readonly IWorkerRepository _workerRepository;
        private readonly IMapper _mapper;

        public PersonsController(IMediator mediator, IUserRepository userRepository, IWorkerRepository workerRepository, IMapper mapper)
        {
            _mediator = mediator;
            _userRepository = userRepository;
            _workerRepository = workerRepository;
            _mapper = mapper;
        }

        [HttpGet("users/populate")]
        public async Task<IEnumerable<UserModel>> PopulateUsers()
        {
            PersonCreatorDelegate guestCreator = Domain.Aggregates.Persons.User.CreateUser;
            var userFactory = new PersonFactory(guestCreator);

            await _userRepository.AddAsync(userFactory.CreatePerson("Janusz", "Kowalski", "G1234", "jkoalski") as User);
            await _userRepository.AddAsync(userFactory.CreatePerson("Antoni", "Nowak", "G4321", "akowalski") as User);
            await _userRepository.Commit();

            var users = await _mediator.Send(new GetAllUsers());

            return _mapper.Map<IEnumerable<UserModel>>(users);
        }

        [HttpGet("workers/populate")]
        public async Task<IEnumerable<WorkerModel>> PopulateWorkers()
        {
            PersonCreatorDelegate workerCreator = Worker.CreateWorker;
            var workerFactory = new PersonFactory(workerCreator);
            await _workerRepository.AddAsync(workerFactory.CreatePerson("Zuzanna", "Kowalska", "W1234", "zkowalska") as Worker);
            await _workerRepository.Commit();

            var workers = await _mediator.Send(new GetAllWorkers());

            return _mapper.Map<IEnumerable<WorkerModel>>(workers);
        }

        [HttpGet("workers")]
        public async Task<IEnumerable<WorkerModel>> GetAllWorkers()
        {
            var workers = await _mediator.Send(new GetAllWorkers());

            return _mapper.Map<IEnumerable<WorkerModel>>(workers);
        }

        [HttpGet("users")]
        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsers());

            return _mapper.Map<IEnumerable<UserModel>>(users);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // GET: UsersController/Delete/5
        [HttpGet("delete/{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }

        // POST: UsersController/Delete/5
        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(id));
            }
            catch
            {
                return Ok();
            }
        }
    }
}

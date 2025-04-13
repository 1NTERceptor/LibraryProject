using Domain.Aggregates.Persons;
using Domain.Repository;
using Library.Domain;
using Library.Messages.Commands.Persons;
using Library.Messages.Models;
using Library.Messages.Queries.Persons;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API.Controllers.Requests;
using REST_API.Populate;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public PersonsController(IMediator mediator, IUserRepository userRepository, IWorkerRepository workerRepository)        
        {
            _mediator = mediator;
            _userRepository = userRepository;
            _workerRepository = workerRepository;
        }

        [HttpGet("users/populate")]
        public async Task<IEnumerable<UserModel>> PopulateUsers()
        {
            PersonCreatorDelegate guestCreator = Domain.Aggregates.Persons.User.CreateUser;
            var userFactory = new PersonFactory(guestCreator);

            await _userRepository.AddAsync(userFactory.CreatePerson("Janusz", "Kowalski", "G1234", "jkoalski") as User);
            await _userRepository.AddAsync(userFactory.CreatePerson("Antoni", "Nowak", "G4321", "akowalski") as User);
            await _userRepository.Commit();

            return await _mediator.Send(new GetAllUsers());
        }

        [HttpGet("workers/populate")]
        public async Task<IEnumerable<WorkerModel>> PopulateWorkers()
        {
            PersonCreatorDelegate workerCreator = Worker.CreateWorker;
            var workerFactory = new PersonFactory(workerCreator);
            await _workerRepository.AddAsync(workerFactory.CreatePerson("Zuzanna", "Kowalska", "W1234", "zkowalska") as Worker);
            await _workerRepository.Commit();

            return await _mediator.Send(new GetAllWorkers());
        }

        [HttpGet("workers")]
        public async Task<IEnumerable<WorkerModel>> GetAllWorkers()
        {
            return await _mediator.Send(new GetAllWorkers());
        }

        [HttpGet("users")]
        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return await _mediator.Send(new GetAllUsers());
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            var command = new CreateUserCommand(request.FirstName, request.LastName, request.GuestCardNumber, request.Login);

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

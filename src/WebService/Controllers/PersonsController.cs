using Library.Domain;
using Library.Domain.Aggregates;
using Library.Messages.Commands.Persons;
using Library.Messages.Models;
using Library.Messages.Queries.Persons;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IDataContext _dataContext;

        public PersonsController(IMediator mediator, IDataContext dataContext)        
        {
            _mediator = mediator;
            _dataContext = dataContext;
        }

        [HttpGet("users/populate")]
        public async Task<IEnumerable<UserModel>> PopulateUsers()
        {
            PersonCreatorDelegate guestCreator = Library.Domain.Aggregates.User.CreateUser;
            var userFactory = new PersonFactory(guestCreator);

            _dataContext.Users.Add(userFactory.CreatePerson("Janusz", "Kowalski", "G1234", "jkoalski") as User);
            _dataContext.Users.Add(userFactory.CreatePerson("Antoni", "Nowak", "G4321", "akowalski") as User);
            await _dataContext.SaveChangesAsync();

            return await _mediator.Send(new GetAllUsers());
        }

        [HttpGet("workers/populate")]
        public async Task<IEnumerable<WorkerModel>> PopulateWorkers()
        {
            PersonCreatorDelegate workerCreator = Worker.CreateWorker;
            var workerFactory = new PersonFactory(workerCreator);
            _dataContext.Workers.Add(workerFactory.CreatePerson("Zuzanna", "Kowalska", "W1234", "zkowalska") as Worker);
            await _dataContext.SaveChangesAsync();

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
            var command = new CreateUserCommand(request.FirstName, request.LastName, request.GuestCardNumber);

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

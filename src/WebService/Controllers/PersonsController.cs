using Library.Messages.Commands.Persons;
using Library.Messages.Models;
using Library.Messages.Queries.Persons;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace REST_API.Controllers
{
    [Route("api/v1/[Area]")]
    [Area("persons")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonsController(IMediator mediator)        
        {
            _mediator = mediator;
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

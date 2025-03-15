using Library.Domain.Aggregates;
using Library.Domain.CQRS.Queries;
using Library.Domain.Repository;
using Library.Messages.Commands;
using Library.Messages.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.Controllers;

namespace REST_API.Controllers
{
    [Route("api/v1/[Area]")]
    [Area("persons")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly ILogger<LibraryController> _logger;
        private readonly IMediator _mediator;
        private readonly IPersonRepository _personRepository;

        public PersonsController(ILogger<LibraryController> logger, IMediator mediator, IPersonRepository personRepository)
        {
            _logger = logger;
            _mediator = mediator;
            _personRepository = personRepository;
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
        public async Task<IActionResult> Create([FromBody] CreateGuestRequest request)
        {
            var command = new CreateGuestCommand(request.FirstName, request.LastName, request.GuestCardNumber);

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

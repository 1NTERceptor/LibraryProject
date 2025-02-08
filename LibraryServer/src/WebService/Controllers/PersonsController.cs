using Library.Domain.Aggregates;
using Library.Domain.CQRS.Commands;
using Library.Domain.CQRS.Queries;
using Library.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly IPeople _persons;
        private readonly IMediator _mediator;

        public PersonsController(ILogger<LibraryController> logger, IPeople persons, IMediator mediator)
        {
            _logger = logger;
            _persons = persons;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return Ok(await _mediator.Send(new GetAllPersons()));
        }

        [HttpGet("borrowed/{id}")]
        public async Task<ActionResult> BorrowedBooks(int id)
        {
            return Ok(await _mediator.Send(new GetGuestBorrowedBooksByGuestId(id)));
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult> Details(int id)
        {
            return Ok(await _mediator.Send(new GetPersonById(id)));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateGuestRequest request)
        {
            var command = new CreateGuestCommand(request.FirstName, request.LastName, request.GuestCardNumber);

            return Ok(await _mediator.Send(command));
        }

        [HttpPost("borrow")]
        public async Task<IActionResult> BorrowBook([FromBody] CreateBorrowBook request)
        {
            var command = new CreateBorrowBook(request.BookId, request.GuestId);

            return Ok(await _mediator.Send(command));
        }

        [HttpPost("edit/{id}")]
        public async Task<ActionResult> Edit(int id, string firstName)
        {
            var person = new Person(firstName, "lastName", "login");
            var result = await _persons.EditPerson(id, person);

            if (result == false)
                return NotFound();

            return Ok();
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }
    }
}

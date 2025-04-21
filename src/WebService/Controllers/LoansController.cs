using Application.CQRS.Commands.Loans;
using Application.CQRS.Queries.Loans;
using Library.Messages.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using REST_API.Controllers.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace REST_API.Controllers
{
    [Route("api/v1/[Area]")]
    [Area("loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoansController(IMediator mediator)        
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<LoanModel>> GetAll()
        {
            return await _mediator.Send(new GetAllLoans());
        }

        [HttpGet("{id}")]
        public async Task<LoanModel> GetById(Guid id)
        {
            return await _mediator.Send(new GetLoanById(id));
        }

        [HttpPost("create")]
        public async Task<Guid> Create([FromBody] CreateLoanRequest request)
        {
            var command = new CreateLoanCommand(request.BookId, request.UserId, request.DateTo);

            return await _mediator.Send(command);
        }

        // GET: UsersController/Delete/5
        [HttpGet("delete/{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}

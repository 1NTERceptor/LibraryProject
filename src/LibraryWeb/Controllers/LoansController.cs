using Application.CQRS.Commands.Loans;
using Application.CQRS.Queries.Loans;
using AutoMapper;
using Library.Messages.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace REST_API.Controllers
{
    [Route("api/v1/[Area]")]
    [Area("loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LoansController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<LoanModel>> GetAll()
        {
            var loans = await _mediator.Send(new GetAllLoans());

            return _mapper.Map<IEnumerable<LoanModel>>(loans);
        }

        [HttpGet("{id}")]
        public async Task<LoanModel> GetById(Guid id)
        {
            var loan = await _mediator.Send(new GetLoanById(id));

            return _mapper.Map<LoanModel>(loan);
        }

        [HttpPost("create")]
        public async Task<Guid> Create([FromBody] CreateLoanCommand command)
        {
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

using Library.Messages.Models;
using MediatR;

namespace Library.Domain.CQRS.Queries
{
    public class GetAllWorkers : IRequest<IEnumerable<WorkerModel>>
    {
    }
}

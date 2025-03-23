using Library.Messages.Models;
using MediatR;

namespace Library.Messages.Queries.Persons
{
    public class GetAllWorkers : IRequest<IEnumerable<WorkerModel>>
    {
    }
}

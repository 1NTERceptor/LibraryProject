using Library.Messages.Events.User;
using Library.Messages.Events.Worker;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.EventHandlers.Persons
{
    public class PersonEventHandlers : 
        INotificationHandler<WorkerCreated>,
        INotificationHandler<UserCreated>
    {
        public PersonEventHandlers()
        {

        }

        public async Task Handle(WorkerCreated notification, CancellationToken cancellationToken)
        {
            return;
        }

        public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
        {
            return;
        }
    }
}

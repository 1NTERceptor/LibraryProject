using Domain.Events.User;
using Domain.Events.Worker;
using MediatR;

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

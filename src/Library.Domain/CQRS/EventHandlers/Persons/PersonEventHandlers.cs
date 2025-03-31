using Library.Messages.Events.User;
using Library.Messages.Events.Worker;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Domain.CQRS.EventHandlers.Persons
{
    public class PersonEventHandlers : 
        INotificationHandler<WorkerCreated>,
        INotificationHandler<GuestCreated>
    {
        public PersonEventHandlers()
        {

        }

        public async Task Handle(WorkerCreated notification, CancellationToken cancellationToken)
        {
            return;
        }

        public async Task Handle(GuestCreated notification, CancellationToken cancellationToken)
        {
            return;
        }
    }
}

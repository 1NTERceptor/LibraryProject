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

        public Task Handle(WorkerCreated notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(GuestCreated notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

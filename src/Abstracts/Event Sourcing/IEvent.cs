using MediatR;

namespace Abstracts.Event_Sourcing
{
    public interface IDomainEvent : INotification
    { }
}

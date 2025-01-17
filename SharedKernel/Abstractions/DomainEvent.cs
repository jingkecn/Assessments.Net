using Mediator;

namespace SharedKernel.Abstractions;

public abstract record DomainEvent : INotification
{
    public DateTime OccuredAt { get; protected set; } = DateTime.UtcNow;
}

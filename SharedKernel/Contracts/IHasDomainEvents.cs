using SharedKernel.Abstractions;

namespace SharedKernel.Contracts;

public interface IHasDomainEvents
{
    IEnumerable<DomainEvent> DomainEvents { get; }
}

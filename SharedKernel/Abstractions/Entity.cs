using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedKernel.Contracts;

namespace SharedKernel.Abstractions;

public abstract class Entity<TId>(TId id) : IHasDomainEvents where TId : struct, IEquatable<TId>
{
    [Key] public TId Id { get; } = id;

    #region Domain Events

    private readonly HashSet<DomainEvent> mDomainEvents = [];

    [NotMapped] public IEnumerable<DomainEvent> DomainEvents => mDomainEvents.ToImmutableList();

    public void AddDomainEvent(DomainEvent domainEvent) => mDomainEvents.Add(domainEvent);
    public void ClearDomainEvents() => mDomainEvents.Clear();
    public void RemoveDomainEvent(DomainEvent domainEvent) => mDomainEvents.Remove(domainEvent);

    #endregion
}

using System.ComponentModel.DataAnnotations;
using SharedKernel.Abstractions;

namespace Users.Domain.Events;

public sealed record UserCreatedDomainEvent([property: Required] Guid Id) : DomainEvent;

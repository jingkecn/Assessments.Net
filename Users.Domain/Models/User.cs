using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedKernel.Abstractions;
using SharedKernel.Contracts;
using Users.Domain.Events;

namespace Users.Domain.Models;

[Table(nameof(User))]
public sealed class User : Entity<Guid>, IAggregateRoot
{
    private User(Guid id, string firstName, string lastName) : base(id) =>
        (FirstName, LastName) = (firstName, lastName);

    [MaxLength(30)] [Required] public string FirstName { get; }
    [MaxLength(30)] [Required] public string LastName { get; }
    [EmailAddress] [Required] public string Email { get; private set; } = null!;
    [Required] public Address Address { get; private set; } = null!;
    [Required] public DateTime LastModifiedAt { get; private set; } = DateTime.UtcNow;

    public static User Create(string firstName, string lastName, string email, Address address)
    {
        ArgumentException.ThrowIfNullOrEmpty(firstName);
        ArgumentException.ThrowIfNullOrEmpty(lastName);
        ArgumentException.ThrowIfNullOrEmpty(email);
        var user = new User(Guid.NewGuid(), firstName, lastName) { Email = email, Address = address };
        user.AddDomainEvent(new UserCreatedDomainEvent(user.Id));
        return user;
    }

    public bool Update(string email, Address address)
    {
        ArgumentException.ThrowIfNullOrEmpty(email);
        if (email == Email && address == Address)
        {
            return false;
        }

        (Email, Address) = (email, address);
        LastModifiedAt = DateTime.UtcNow;
        AddDomainEvent(new UserUpdatedDomainEvent(Id));
        return true;
    }
}

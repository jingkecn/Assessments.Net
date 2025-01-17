using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Users.Domain.Models;

[ComplexType]
public record Address
{
    public Address(string country, string city, string postCode, string street)
    {
        ArgumentException.ThrowIfNullOrEmpty(country);
        ArgumentException.ThrowIfNullOrEmpty(city);
        ArgumentException.ThrowIfNullOrEmpty(postCode);
        ArgumentException.ThrowIfNullOrEmpty(street);
        Country = country;
        City = city;
        PostCode = postCode;
        Street = street;
    }

    [Required] public string Country { get; init; }
    [Required] public string City { get; init; }
    [Required] public string PostCode { get; init; }
    [Required] public string Street { get; init; }

    public void Deconstruct(out string country, out string city, out string postCode, out string street)
    {
        country = Country;
        city = City;
        postCode = PostCode;
        street = Street;
    }
}

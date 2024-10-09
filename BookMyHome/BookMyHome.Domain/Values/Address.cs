using Microsoft.Extensions.DependencyInjection;
using BookMyHome.Domain.DomainServiceInterface;

namespace BookMyHome.Domain.Values;

public record Address : ValueBase
{
    protected Address()
    {
    }

    private Address(string street, string building, string zipCode, string city, AddressValidationResult dawaValidationRespose)
    {
        Street = street;
        Building = building;
        ZipCode = zipCode;
        City = city;
        ValidationState = dawaValidationRespose.ValidationState;
        DawaId = dawaValidationRespose.DawaId;
    }

    public string Street { get; private set; }
    public string Building { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }
    public bool isValid => ValidationState == AddressValidationState.Valid || ValidationState == AddressValidationState.Pending;
    public string DawaId { get; protected set; }
    public AddressValidationState ValidationState { get; protected set; }

    public static Address Create(string street, string building, string zipCode, string city, IServiceProvider serviceProvider)
    {
        var dawaService = serviceProvider.GetRequiredService<IValidateAddressDomainService>();
        var dawaValidationRespose = dawaService.ValidateAddress(street, building, city);
        return new Address(street, building, zipCode, city, dawaValidationRespose);
        return new();
    }
}

public enum AddressValidationState
{
    NotValidated,
    Pending,
    Valid,
    Invalid
}
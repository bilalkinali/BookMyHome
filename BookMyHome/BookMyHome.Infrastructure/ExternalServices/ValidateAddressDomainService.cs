using BookMyHome.Application.Command.CommandDto.Accommodation;
using BookMyHome.Domain.DomainServices;
using BookMyHome.Domain.Values;

namespace BookMyHome.Infrastructure.ExternalServices;

public class ValidateAddressDomainService : IValidateAddressDomainService
{
    private readonly IAddressServiceProxy _addressService;

    public ValidateAddressDomainService(IAddressServiceProxy addressService)
    {
        _addressService = addressService;
    }

    AddressValidationResult IValidateAddressDomainService.ValidateAddress(string street, string building, string zipCode, string city)
    {
        var dawaCorrelationId = Guid.NewGuid();
        var result = _addressService.ValidateAddressAsync(dawaCorrelationId, street, building, zipCode, city).Result;
        return new AddressValidationResult(result.DawaCorrelationId, result.DawaId, Map(result.ValidationState));
    }

    private AddressValidationState Map(AddressValidationStateDto state)
    {
        switch (state)
        {
            case AddressValidationStateDto.Valid:
                return AddressValidationState.Valid;
            case AddressValidationStateDto.Pending:
                return AddressValidationState.Pending;
            case AddressValidationStateDto.Uncertain:
                return AddressValidationState.Uncertain;
            case AddressValidationStateDto.Invalid:
                return AddressValidationState.Invalid;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
}
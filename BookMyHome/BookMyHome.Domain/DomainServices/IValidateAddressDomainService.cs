using BookMyHome.Domain.Values;

namespace BookMyHome.Domain.DomainServices
{
    public interface IValidateAddressDomainService
    {
        AddressValidationResult ValidateAddress(string street, string building, string zipCode, string city);
    }

    public record AddressValidationResult(Guid DawaCorrelationId, Guid DawaId, AddressValidationState ValidationState);
}

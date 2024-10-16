using AddressServiceDAWA.Domain.Values;

namespace AddressServiceDawa.Domain.DomainServices
{
    public interface IValidateAddressDomainService
    {
        AddressValidationResult ValidateAddress(string street, string building, string zipCode, string city);
    }

    public record AddressValidationResult(string DawaId, AddressValidationState ValidationState);
}

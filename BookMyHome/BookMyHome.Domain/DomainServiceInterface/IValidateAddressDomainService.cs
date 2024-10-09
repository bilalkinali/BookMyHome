using BookMyHome.Domain.Values;

namespace BookMyHome.Domain.DomainServiceInterface
{
    public interface IValidateAddressDomainService
    {
        AddressValidationResult ValidateAddress(string street, string building, string zipCode);
    }

    public record AddressValidationResult(string DawaId, AddressValidationState ValidationState);
}

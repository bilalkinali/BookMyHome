using BookMyHome.Domain.DomainServiceInterface;
using BookMyHome.Domain.Values;

namespace BookMyHome.Infrastructure.ExternalServices
{
    public class ValidateAddressDomainService : IValidateAddressDomainService
    {
        private readonly IAddressServiceProxy _addressService;

        public ValidateAddressDomainService(IAddressServiceProxy addressService)
        {
            _addressService = addressService;
        }
        AddressValidationResult IValidateAddressDomainService.ValidateAddress(string street, string building, string zipCode)
        {
            var result = _addressService.ValidateAddressAsync(street, building, zipCode).Result;
            return new AddressValidationResult(result.DawaId, (AddressValidationState)result.state);
        }
    }
}

using AddressServiceDAWA.Domain.Entity;

namespace AddressServiceDAWA.Application;

public interface IBookMyHomeProxy
{
    Task SendValidatedAddressAsync(Address address);
}
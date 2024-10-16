using AddressServiceDAWA.Domain.Entity;

namespace AddressServiceDAWA.Application.Query;

public interface IAddressQuery
{
    IEnumerable<Address> GetUnvalidatedAddresses();
}
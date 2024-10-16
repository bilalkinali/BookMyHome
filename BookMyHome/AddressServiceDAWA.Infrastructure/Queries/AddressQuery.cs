using AddressServiceDAWA.Application.Query;
using AddressServiceDAWA.Domain.Entity;
using AddressServiceDAWA.Domain.Values;

namespace AddressServiceDAWA.Infrastructure.Queries;

public class AddressQuery : IAddressQuery
{
    private readonly AddressContext _db;

    public AddressQuery(AddressContext db)
    {
        _db = db;
    }

    IEnumerable<Address> IAddressQuery.GetUnvalidatedAddresses()
    {
        return _db.Addresses.Where(a => a.DawaAddress.ValidationState == AddressValidationState.Pending).ToList();
    }
}
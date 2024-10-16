using AddressServiceDAWA.Domain.Entity;

namespace AddressServiceDAWA.Application.Command;

public interface IAddressRepository
{
    Address? GetAddress(string street, string building, string zipCode, string city);
    void Add(Address? address);
    Address GetAddress(int id);
    void Update();
}
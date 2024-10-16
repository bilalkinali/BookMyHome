using AddressServiceDAWA.Application.Command.CommandDto;
using AddressServiceDAWA.Domain.Entity;

namespace AddressServiceDAWA.Application.Command;

public interface IAddressCommand
{
    Address CreateAddress(CreateAddressCommandDto command);
    IEnumerable<Address> ValidateAddress(int id);
}
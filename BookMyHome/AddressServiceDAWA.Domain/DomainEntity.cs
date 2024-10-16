using System.ComponentModel.DataAnnotations;

namespace AddressServiceDawa.Domain;

public abstract class DomainEntity
{
    public int Id { get; protected set; }

    [Timestamp] public byte[] RowVersion { get; protected set; }
}
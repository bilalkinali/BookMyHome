using AddressServiceDAWA.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AddressServiceDAWA.Infrastructure;

public class AddressContext : DbContext
{
    public AddressContext(DbContextOptions<AddressContext> options)
        : base(options)
    {
    }

    public DbSet<Address?> Addresses { get; set; }
}
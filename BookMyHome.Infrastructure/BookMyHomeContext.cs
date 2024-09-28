using Microsoft.EntityFrameworkCore;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Infrastructure
{
    public class BookMyHomeContext : DbContext
    {
        public BookMyHomeContext(DbContextOptions<BookMyHomeContext> options) : base(options) { }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}

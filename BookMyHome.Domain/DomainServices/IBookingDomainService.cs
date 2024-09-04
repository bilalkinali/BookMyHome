using BookMyHome.Domain.Entity;

namespace BookMyHome.Domain.DomainServices
{
    public interface IBookingDomainService
    {
        IEnumerable<Booking> GetOtherBookings(Booking booking);
    }
}

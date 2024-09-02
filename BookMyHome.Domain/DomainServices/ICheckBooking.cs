using BookMyHome.Domain.Entity;

namespace BookMyHome.Domain.DomainServices
{
    public interface IBookingDomainService
    {
        IEnumerable<Booking> GetOtherBookings(Booking booking);
    }

    public class CheckBooking : IBookingDomainService
    {
        public IEnumerable<Booking> GetOtherBookings(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}

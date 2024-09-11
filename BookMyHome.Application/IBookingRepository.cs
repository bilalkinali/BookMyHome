using BookMyHome.Domain.Entity;

namespace BookMyHome.Application
{
    public interface IBookingRepository
    {
        void AddBooking(Booking booking);
        Booking GetBooking(int id);
        void UpdateBooking(Booking booking, byte[] rowVersion);
        void DeleteBooking(Booking booking, byte[] rowVersion);
    }
}

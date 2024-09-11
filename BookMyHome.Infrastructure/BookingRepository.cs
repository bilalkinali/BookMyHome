using BookMyHome.Application;
using BookMyHome.Domain.Entity;
using Microsoft.VisualBasic;

namespace BookMyHome.Infrastructure
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookMyHomeContext _db;

        public BookingRepository(BookMyHomeContext context)
        {
            _db = context;
        }

        void IBookingRepository.AddBooking(Booking booking)
        {
            _db.Bookings.Add(booking);
            _db.SaveChanges();
        }

        Booking IBookingRepository.GetBooking(int id)
        {
            return _db.Bookings.Single(b => b.Id == id);
        }

        void IBookingRepository.UpdateBooking(Booking booking, byte[] rowversion)
        {
            _db.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowversion;
            _db.SaveChanges();
        }

        void IBookingRepository.DeleteBooking(Booking booking, byte[] rowversion)
        {
            // --- RowVersion?
            _db.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowversion;
            _db.Bookings.Remove(booking);
            _db.SaveChanges();
        }
    }
}

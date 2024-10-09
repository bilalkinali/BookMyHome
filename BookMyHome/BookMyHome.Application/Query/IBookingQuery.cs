using BookMyHome.Application.Query.QueryDto;

namespace BookMyHome.Application.Query
{
    public interface IBookingQuery
    {
        BookingDto GetBooking(int accommodationId, int bookingId);
        IEnumerable<BookingDto> GetBookings();
        IEnumerable<BookingDto> GetBookingsForAccommodation(int accommodationId);
    }

    /// <summary>
    /// Data transfer object for booking
    /// </summary>
}

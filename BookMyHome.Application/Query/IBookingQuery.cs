namespace BookMyHome.Application.Query
{
    public interface IBookingQuery
    {
        BookingDto GetBooking(int id);
        IEnumerable<BookingDto> GetBookings();
    }

    /// <summary>
    /// Data transfer object for booking
    /// </summary>

    public class BookingDto
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public byte[] RowVersion { get; set; }
    }
}

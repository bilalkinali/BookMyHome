using BookMyHome.Application.Query;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure.Queries;

public class BookingQuery : IBookingQuery
{
    private readonly BookMyHomeContext _db;

    public BookingQuery(BookMyHomeContext db)
    {
        _db = db;
    }

    BookingDto IBookingQuery.GetBooking(int id)
    {
        var booking = _db.Bookings.AsNoTracking().Single(b => b.Id == id);
        return new BookingDto
        {
            Id = booking.Id,
            StartDate = booking.StartDate,
            EndDate = booking.EndDate,
            RowVersion = booking.RowVersion
        };
    }

    IEnumerable<BookingDto> IBookingQuery.GetBookings()
    {
        var result = _db.Bookings.AsNoTracking()
            .Select(b => new BookingDto
            {
                Id = b.Id,
                StartDate = b.StartDate,
                EndDate = b.EndDate,
                RowVersion = b.RowVersion
            });
        return result;
    }

    IEnumerable<BookingDto> IBookingQuery.GetBookingsForAccommodation(int id)
    {
        var result = _db.Bookings.AsNoTracking()
            .Where(b => b.Accommodation.Id == id)
            .Select(b => new BookingDto
            {
                Id = b.Id,
                StartDate = b.StartDate,
                EndDate = b.EndDate,
                RowVersion = b.RowVersion
            });
        return result;
    }
}
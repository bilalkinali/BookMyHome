using BookMyHome.Application.Query;
using BookMyHome.Application.Query.QueryDto;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure.Queries;

public class BookingQuery : IBookingQuery
{
    private readonly BookMyHomeContext _db;

    public BookingQuery(BookMyHomeContext db)
    {
        _db = db;
    }

    BookingDto IBookingQuery.GetBooking(int accommodationId, int bookingId)
    {
        var accommodation = _db.Accommodations
            .Include(a => a.Bookings)
            .AsNoTracking()
            .Single(a => a.Id == bookingId);

        var booking = accommodation.Bookings.Single(b => b.Id == bookingId);

        return new BookingDto
        {
            Id = booking.Id,
            StartDate = booking.StartDate,
            EndDate = booking.EndDate,
            AccommodationId = accommodation.Id,
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
    
    IEnumerable<BookingDto> IBookingQuery.GetBookingsForAccommodation(int accommodationId)
    {
        var accomodation = _db.Accommodations
            .Include(b => b.Bookings)
            .AsNoTracking()
            .Single(a => a.Id == accommodationId);

        var result = accomodation.Bookings.Select(b => new BookingDto
        {
            Id = b.Id,
            StartDate = b.StartDate,
            EndDate = b.EndDate,
            AccommodationId = accomodation.Id,
            RowVersion = b.RowVersion
        });

        return result;
    }
}
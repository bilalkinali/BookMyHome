using BookMyHome.Application.RepositoryInterface;
using BookMyHome.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure.Repositories;

public class AccommodationRepository : IAccommodationRepository
{
    private readonly BookMyHomeContext _db;

    public AccommodationRepository(BookMyHomeContext context)
    {
        _db = context;
    }

    void IAccommodationRepository.Add(Accommodation accommodation)
    {
        _db.Accommodations.Add(accommodation);
        _db.SaveChanges();
    }

    Accommodation IAccommodationRepository.GetAccommodation(int id)
    {
        return _db.Accommodations
            .Include(a => a.Bookings)
            .Single(a => a.Id == id);
    }

    //Accommodation IAccommodationRepository.GetAccommodationWithBookingId(int id)
    //{
    //    return _db.Accommodations
    //        .Where(a => a.Bookings
    //            .Any(b => b.Id == 1))
    //        .First();
    //}

    void IAccommodationRepository.Update(Accommodation accommodation, byte[] rowVersion)
    {
        _db.Entry(accommodation).Property(nameof(accommodation.RowVersion)).OriginalValue = rowVersion;
        _db.SaveChanges();
    }

    void IAccommodationRepository.Update(Accommodation accommodation)
    {
        _db.SaveChanges();
    }

    void IAccommodationRepository.Delete(Accommodation accommodation, byte[] rowVersion)
    {
        _db.Entry(accommodation).Property(nameof(accommodation.RowVersion)).OriginalValue = rowVersion;
        _db.Accommodations.Remove(accommodation);
        _db.SaveChanges();
    }

    // Booking

    void IAccommodationRepository.AddBooking(Accommodation accommodation)
    {
        _db.SaveChanges();
    }

    void IAccommodationRepository.UpdateBooking(Booking booking, byte[] rowVersion)
    {
        _db.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowVersion;
        _db.SaveChanges();
    }

    void IAccommodationRepository.DeleteBooking(Booking booking, byte[] rowVersion)
    {
        _db.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowVersion;
        _db.Bookings.Remove(booking);
        _db.SaveChanges();
    }

    Accommodation IAccommodationRepository.getAccommodationByDawaCorrelationId(Guid dawaCorrelationId)
    {
        return _db.Accommodations
            .Include(a => a.Bookings)
            .First(a => a.Address.DawaCorrelationId == dawaCorrelationId);
    }
}
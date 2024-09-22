using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.RepositoryInterface
{
    public interface IAccommodationRepository
    {
        void Add(Accommodation accommodation);
        Accommodation GetAccommodation(int id);
        void Update(Accommodation accommodation, byte[] rowVersion);
        void Delete(Accommodation accommodation, byte[] rowVersion);

        // Booking
        void AddBooking(Accommodation accommodation);
        void UpdateBooking(Booking booking, byte[] rowVersion);
        void DeleteBooking(Booking booking, byte[] rowVersion);
    }
}

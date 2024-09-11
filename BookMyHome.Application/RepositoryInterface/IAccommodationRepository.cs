using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.RepositoryInterface
{
    public interface IAccommodationRepository
    {
        void AddAccommodation(Accommodation accommodation);
        Accommodation GetAccommodation(int id);
        void UpdateAccommodation(Accommodation accommodation, byte[] rowVersion);
        void DeleteAccommodation(Accommodation accommodation, byte[] rowVersion);
    }
}

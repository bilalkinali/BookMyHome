using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.RepositoryInterface
{
    public interface IGuestRepository
    {
        void Add(Guest guest);
    }
}

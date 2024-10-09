using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.RepositoryInterface
{
    public interface IHostRepository
    {
        void Add(Host host);
        Host Get(int id);
    }
}

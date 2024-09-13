using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.RepositoryInterface
{
    public interface IHostRepository
    {
        void AddHost(Host host);
        Host GetHost(int id);
    }
}

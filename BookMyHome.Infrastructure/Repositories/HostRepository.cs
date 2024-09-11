using BookMyHome.Application.RepositoryInterface;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Infrastructure.Repositories
{
    internal class HostRepository : IHostRepository
    {
        private readonly BookMyHomeContext _db;
        public HostRepository(BookMyHomeContext context)
        {
            _db = context;
        }
        void IHostRepository.AddHost(Host host)
        {
            throw new NotImplementedException();
        }

        Host IHostRepository.GetHost(int id)
        {
            return _db.Hosts.Single(h => h.Id == id);
        }
    }
}

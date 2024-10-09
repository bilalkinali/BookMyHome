using BookMyHome.Application.RepositoryInterface;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Infrastructure.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly BookMyHomeContext _db;

        public GuestRepository(BookMyHomeContext db)
        {
            _db = db;
        }

        void IGuestRepository.Add(Guest guest)
        {
            _db.Guests.Add(guest);
            _db.SaveChanges();
        }
    }
}

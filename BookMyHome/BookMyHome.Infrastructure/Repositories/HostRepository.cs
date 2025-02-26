﻿using BookMyHome.Application.RepositoryInterface;
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
        void IHostRepository.Add(Host host)
        {
            _db.Hosts.Add(host);
            _db.SaveChanges();
        }

        Host IHostRepository.Get(int id)
        {
            return _db.Hosts.Single(h => h.Id == id);
        }
    }
}

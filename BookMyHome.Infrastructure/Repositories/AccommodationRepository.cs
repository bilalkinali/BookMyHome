﻿using BookMyHome.Application.RepositoryInterface;
using BookMyHome.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure.Repositories
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private readonly BookMyHomeContext _db;
        public AccommodationRepository(BookMyHomeContext context)
        {
            _db = context;
        }

        void IAccommodationRepository.AddAccommodation(Accommodation accommodation)
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

        void IAccommodationRepository.UpdateAccommodation(Accommodation accommodation, byte[] rowVersion)
        {
            _db.Entry(accommodation).Property(nameof(accommodation.RowVersion)).OriginalValue = rowVersion;
            _db.SaveChanges();
        }

        void IAccommodationRepository.DeleteAccommodation(Accommodation accommodation, byte[] rowVersion)
        {
            _db.Entry(accommodation).Property(nameof(accommodation.RowVersion)).OriginalValue = rowVersion;
            _db.Accommodations.Remove(accommodation);
            _db.SaveChanges();
        }
    }
}

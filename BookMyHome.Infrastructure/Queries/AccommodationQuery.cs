﻿using BookMyHome.Application.Query;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure.Queries
{
    public class AccommodationQuery : IAccommodationQuery
    {
        private readonly BookMyHomeContext _db;
        public AccommodationQuery(BookMyHomeContext db)
        {
            _db = db;
        }

        AccommodationDto IAccommodationQuery.GetAccommodation(int id)
        {
            var accommodation = _db.Accommodations.AsNoTracking().Single(a => a.Id == id);
            return new AccommodationDto
            {
                Id = accommodation.Id,
                Price = accommodation.Price,
                RowVersion = accommodation.RowVersion
            };
        }

        IEnumerable<AccommodationDto> IAccommodationQuery.GetAccommodations()
        {
            var result = _db.Accommodations.AsNoTracking()
                .Select(a => new AccommodationDto
                {
                    Id = a.Id,
                    Price = a.Price,
                    RowVersion = a.RowVersion
                });
            return result;
        }
    }
}

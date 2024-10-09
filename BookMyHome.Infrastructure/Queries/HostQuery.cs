using BookMyHome.Application.Query;
using BookMyHome.Application.Query.QueryDto;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure.Queries;

internal class HostQuery : IHostQuery
{
    private readonly BookMyHomeContext _db;

    public HostQuery(BookMyHomeContext db)
    {
        _db = db;
    }

    HostDto? IHostQuery.GetAccommodations(int hostId)
    {
        var host = _db.Hosts
            //.AsNoTracking()? // ?
            .Include(a => a.Accommodations)
                .ThenInclude(b => b.Bookings)
            .FirstOrDefault(h => h.Id == hostId);

        if (host == null) return null;

        return new HostDto
        {
            Id = host.Id,
            Accommodations = host.Accommodations.Select(a => new AccommodationDto
            {
                Id = a.Id, // protected get; -> doesn't show in JSON
                Price = a.Price,
                HostId = a.Host.Id,
                Bookings = a.Bookings.Select(b => new BookingDto
                {
                    Id = b.Id,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate,
                    AccommodationId = a.Id, // Remove?
                    RowVersion = b.RowVersion
                })
            })
        };
    }

    HostDto? IHostQuery.GetReviews(int hostId)
    {
        var host = _db.Hosts
            .Include(h => h.Accommodations)
                .ThenInclude(a => a.Reviews)
            .FirstOrDefault(h => h.Id == hostId);

        if (host == null) return null;

        return new HostDto
        {
            Id = host.Id,
            Accommodations = host.Accommodations.Select(a => new AccommodationDto
            {
                Id = a.Id,
                Price = a.Price,
                HostId = a.Host.Id,
                Reviews = a.Reviews.Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    Date = r.Date
                })
            })
        };
    }

    //HostDto IHostQuery.GetHost(int id)
    //{
    //    var host = _db.Hosts.AsNoTracking()
    //        .Single(h => h.Id == id);
    //    return new HostDto
    //    {
    //        Id = host.Id,
    //        RowVersion = host.RowVersion
    //    };
    //}

    //IEnumerable<HostDto> IHostQuery.GetHosts()
    //{
    //    var hosts = _db.Hosts
    //        .AsNoTracking()
    //        .Select(h => new HostDto
    //        {
    //            Id = h.Id
    //        });

    //    return hosts;
    //}
}
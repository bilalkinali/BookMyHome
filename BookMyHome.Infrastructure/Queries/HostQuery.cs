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
            //.AsNoTracking()?
            .Include(a => a.Accommodations)
            .ThenInclude(b => b.Bookings)
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
                Bookings = a.Bookings.Select(b => new BookingDto
                {
                    Id = b.Id,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate,
                    AccommodationId = a.Id,
                    RowVersion = b.RowVersion
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
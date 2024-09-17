using BookMyHome.Application.Query;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Infrastructure.Queries;

internal class HostQuery : IHostQuery
{
    private readonly BookMyHomeContext _db;

    public HostQuery(BookMyHomeContext db)
    {
        _db = db;
    }

    HostDto IHostQuery.GetHost(int id)
    {
        var host = _db.Hosts.AsNoTracking()
            .Single(h => h.Id == id);
        return new HostDto
        {
            Id = host.Id,
            RowVersion = host.RowVersion
        };
    }

    IEnumerable<HostDto> IHostQuery.GetHosts()
    {
        var hosts = _db.Hosts.AsNoTracking()
            .Select(h => new HostDto
            {
                Id = h.Id,
                RowVersion = h.RowVersion
            });
        return hosts;
    }
}
namespace BookMyHome.Application.Query.QueryDto;

public class HostDto
{
    public int Id { get; set; }
    public IEnumerable<AccommodationDto>? Accommodations { get; set; }
}
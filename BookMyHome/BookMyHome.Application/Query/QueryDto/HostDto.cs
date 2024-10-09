namespace BookMyHome.Application.Query.QueryDto;

public record HostDto
{
    public int Id { get; set; }
    public IEnumerable<AccommodationDto>? Accommodations { get; set; }
}
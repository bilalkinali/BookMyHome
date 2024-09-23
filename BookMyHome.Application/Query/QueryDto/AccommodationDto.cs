namespace BookMyHome.Application.Query.QueryDto;

public record AccommodationDto
{
    public int Id { protected get; set; }
    public double Price { get; set; }
    public IEnumerable<BookingDto>? Bookings { get; set; }
    public int HostId { get; set; }
}
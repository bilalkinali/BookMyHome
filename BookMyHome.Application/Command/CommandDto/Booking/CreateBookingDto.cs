namespace BookMyHome.Application.Command.CommandDto.Booking;

public record CreateBookingDto
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int AccommodationId { get; set; }
}
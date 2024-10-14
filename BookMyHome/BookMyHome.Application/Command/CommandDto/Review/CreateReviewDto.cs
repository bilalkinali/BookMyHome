namespace BookMyHome.Application.Command.CommandDto.Review
{
    public record CreateReviewDto(int AccommodationId, int BookingId, string Comment, int Rating, byte[] RowVersion = null!);
}

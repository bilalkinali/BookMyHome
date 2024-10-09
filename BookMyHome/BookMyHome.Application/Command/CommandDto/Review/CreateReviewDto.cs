namespace BookMyHome.Application.Command.CommandDto.Review
{
    public record CreateReviewDto(int AccommodationId, int BokingId, string Comment, int Rating, byte[] RowVersion = null!);
}

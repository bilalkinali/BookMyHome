namespace BookMyHome.Application.Command.CommandDto.Review
{
    public record CreateReviewDto
    {
        public double Rating { get; set; }
        public string? Comment { get; set; }
        public DateOnly Date { get; set; }
        public int BookingId { get; set; }
    }
}

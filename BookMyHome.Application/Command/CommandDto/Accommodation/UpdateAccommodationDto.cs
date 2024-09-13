namespace BookMyHome.Application.Command.CommandDto.Accommodation
{
    public record UpdateAccommodationDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public byte[] RowVersion { get; set; }
    }
}

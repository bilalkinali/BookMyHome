namespace BookMyHome.Application.Command.CommandDto.Accommodation
{
    public record UpdateAccommodationDto
    {
        public int HostId { get; init; }
        public int Id { get; init; }
        public double Price { get; set; }
        public byte[] RowVersion { get; set; }
    }
}

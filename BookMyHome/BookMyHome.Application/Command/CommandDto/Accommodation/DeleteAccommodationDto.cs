namespace BookMyHome.Application.Command.CommandDto.Accommodation
{
    public record DeleteAccommodationDto
    {
        public int HostId { get; init; }
        public int Id { get; init; }
        public byte[] RowVersion { get; set; }
    }
}

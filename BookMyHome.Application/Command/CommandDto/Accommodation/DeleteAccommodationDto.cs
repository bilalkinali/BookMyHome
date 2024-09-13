namespace BookMyHome.Application.Command.CommandDto.Accommodation
{
    public record DeleteAccommodationDto
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}

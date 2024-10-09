namespace BookMyHome.Application.Command.CommandDto.Accommodation
{
    public record CreateAccommodationDto
    {
        public double Price { get; set; }
        public int HostId { get; set; }
    }
}

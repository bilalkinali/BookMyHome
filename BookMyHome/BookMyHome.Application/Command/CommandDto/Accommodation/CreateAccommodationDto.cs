namespace BookMyHome.Application.Command.CommandDto.Accommodation
{
    public record CreateAccommodationDto(int HostId, string Street, string Building, string ZipCode, string City);
}

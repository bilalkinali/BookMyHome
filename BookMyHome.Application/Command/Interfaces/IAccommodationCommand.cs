using BookMyHome.Application.Command.CommandDto.Accommodation;

namespace BookMyHome.Application.Command.Interfaces
{
    public interface IAccommodationCommand
    {
        void CreateAccommodation(CreateAccommodationDto createAccommodationDto);
        void UpdateAccommodation(UpdateAccommodationDto updateAccommodationDto);
        void DeleteAccommodation(DeleteAccommodationDto deleteAccommodationDto);
    }
}

using BookMyHome.Application.Command.CommandDto.Accommodation;
using BookMyHome.Application.Command.CommandDto.Booking;

namespace BookMyHome.Application.Command.Interfaces
{
    public interface IAccommodationCommand
    {
        void Create(CreateAccommodationDto createAccommodationDto);
        void Update(UpdateAccommodationDto updateAccommodationDto);
        void Delete(DeleteAccommodationDto deleteAccommodationDto);
        void CreateBooking(CreateBookingDto bookingDto);
        void UpdateBooking(UpdateBookingDto updateBookingDto);
        void DeleteBooking(DeleteBookingDto deleteBookingDto);
    }
}

using BookMyHome.Application.Command.CommandDto.Booking;

namespace BookMyHome.Application.Command.Interfaces
{
    public interface IBookingCommand
    {
        void CreateBooking(CreateBookingDto creatBbookingDto);
        void UpdateBooking(UpdateBookingDto updateBookingDto);
        void DeleteBooking(DeleteBookingDto deleteBookingDto);
    }
}

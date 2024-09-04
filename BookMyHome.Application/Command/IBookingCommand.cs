using BookMyHome.Application.Command.CommandDto;

namespace BookMyHome.Application.Command
{
    public interface IBookingCommand
    {
        void CreateBooking(CreateBookingDto creatBbookingDto);
        void UpdateBooking(UpdateBookingDto updateBookingDto);
        void DeleteBooking(DeleteBookingDto deleteBookingDto);
    }
}

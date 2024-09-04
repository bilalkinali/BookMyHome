namespace BookMyHome.Application.Command
{
    public interface IBookingCommand
    {
        void CreateBooking(CreateBookingDto creatBbookingDto);
        void UpdateBooking(UpdateBookingDto updateBookingDto);
        void DeleteBooking(DeleteBookingDto deleteBookingDto);
    }

    public class CreateBookingDto
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
    public class UpdateBookingDto
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
    public class DeleteBookingDto
    {
    }




}

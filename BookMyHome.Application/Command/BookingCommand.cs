using BookMyHome.Domain.DomainServices;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.Command
{
    public class BookingCommand : IBookingCommand
    {
        private readonly IBookingRepository _repository;
        private readonly IBookingDomainService _domainService;

        public BookingCommand(IBookingRepository repository, IBookingDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }
        void IBookingCommand.CreateBooking(CreateBookingDto createBookingDto)
        {
            // Do
            var booking = Booking.Create(createBookingDto.StartDate, createBookingDto.EndDate, _domainService);

            // Save
            _repository.AddBooking(booking);
        }
        void IBookingCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            // Load
            var booking = _repository.GetBooking(updateBookingDto.Id);

            // Do
            booking.Update(updateBookingDto.StartDate, updateBookingDto.EndDate, _domainService);

            // Save
            _repository.UpdateBooking(booking);
        }

        void IBookingCommand.DeleteBooking(DeleteBookingDto deleteBookingDto)
        {
            // Load
            
            // Do
            // Save
        }
    }
}

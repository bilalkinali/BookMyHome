using BookMyHome.Application.Command.CommandDto;
using BookMyHome.Application.Helpers;
using BookMyHome.Domain.DomainServices;
using BookMyHome.Domain.Entity;
using System.Data;

namespace BookMyHome.Application.Command
{
    public class BookingCommand : IBookingCommand
    {
        private readonly IBookingRepository _repository;
        private readonly IBookingDomainService _domainService;
        private readonly IUnitOfWork _unitOfWork;

        public BookingCommand(IBookingRepository repository, IBookingDomainService domainService, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _domainService = domainService;
            _unitOfWork = unitOfWork;
        }
        void IBookingCommand.CreateBooking(CreateBookingDto createBookingDto)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);

                // Do
                var booking = Booking.Create(createBookingDto.StartDate, createBookingDto.EndDate, _domainService);
                // Save
                _repository.AddBooking(booking);

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
        void IBookingCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);

                // Load
                var booking = _repository.GetBooking(updateBookingDto.Id);
                // Do
                booking.Update(updateBookingDto.StartDate, updateBookingDto.EndDate, _domainService);
                // Save
                _repository.UpdateBooking(booking, updateBookingDto.RowVersion);

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        void IBookingCommand.DeleteBooking(DeleteBookingDto deleteBookingDto)
        {
            // Load            

            // Do

            // Save
        }
    }
}

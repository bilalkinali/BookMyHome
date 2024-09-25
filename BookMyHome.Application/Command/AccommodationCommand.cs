using BookMyHome.Application.Command.CommandDto.Accommodation;
using BookMyHome.Application.Command.CommandDto.Booking;
using BookMyHome.Application.Command.CommandDto.Review;
using BookMyHome.Application.Command.Interfaces;
using BookMyHome.Application.Helpers;
using BookMyHome.Application.RepositoryInterface;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.Command
{
    public class AccommodationCommand : IAccommodationCommand
    {
        // Fix
        private readonly IAccommodationRepository _repository;
        private readonly IHostRepository _hostRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccommodationCommand(IAccommodationRepository accommodationRepository, IHostRepository hostRepository, IUnitOfWork unitOfWork)
        {
            _repository = accommodationRepository;
            _hostRepository = hostRepository;
            _unitOfWork = unitOfWork;
        }
        void IAccommodationCommand.Create(CreateAccommodationDto createAccommodationDto)
        {
            try
            {
                // Load
                var host = _hostRepository.Get(createAccommodationDto.HostId);

                _unitOfWork.BeginTransaction(); // Transaction for phantom read

                // Do
                var accommodation = Accommodation.Create(createAccommodationDto.Price, host);
                // Save
                _repository.Add(accommodation);

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                try
                {
                    _unitOfWork.Rollback();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Rollback failed: {ex.Message}", ex);
                }
                throw;
            }
        }

        void IAccommodationCommand.Update(UpdateAccommodationDto updateAccommodationDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                // Load
                var accommodation = _repository.GetAccommodation(updateAccommodationDto.Id);
                // Do
                accommodation.Update(updateAccommodationDto.Price);
                // Save
                _repository.Update(accommodation, updateAccommodationDto.RowVersion);

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                try
                {
                    _unitOfWork.Rollback();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Rollback failed: {ex.Message}", ex);
                }
                throw;
            }
        }

        void IAccommodationCommand.Delete(DeleteAccommodationDto deleteAccommodationDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                // Load
                var accommodation = _repository.GetAccommodation(deleteAccommodationDto.Id);
                //Do & Save
                _repository.Delete(accommodation, deleteAccommodationDto.RowVersion);

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                try
                {
                    _unitOfWork.Rollback();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Rollback failed: {ex.Message}", ex);
                }
                throw;
            }
        }

        // Booking

        void IAccommodationCommand.CreateBooking(CreateBookingDto bookingDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                // Load
                Accommodation accommodation = _repository.GetAccommodation(bookingDto.AccommodationId);
                // Do
                accommodation.CreateBooking(bookingDto.StartDate, bookingDto.EndDate);
                // Save
                _repository.AddBooking(accommodation);

                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    _unitOfWork.Rollback();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Rollback failed: {ex.Message}", ex);
                }
                throw;
            }
        }

        void IAccommodationCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                // Load
                Accommodation accommodation = _repository.GetAccommodation(updateBookingDto.AccommodationId);
                // Do
                var booking = accommodation.UpdateBooking(updateBookingDto.Id, updateBookingDto.StartDate, updateBookingDto.EndDate);
                // Save
                _repository.UpdateBooking(booking, updateBookingDto.RowVersion);

                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    _unitOfWork.Rollback();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Rollback failed: {ex.Message}", ex);
                }
                throw;
            }
        }

        void IAccommodationCommand.DeleteBooking(DeleteBookingDto deleteBookingDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                // Load            
                var accommodation = _repository.GetAccommodation(deleteBookingDto.AccommodationId);
                // Do
                var booking = accommodation.Bookings.Single(b => b.Id == deleteBookingDto.Id);
                // Save
                _repository.DeleteBooking(booking, deleteBookingDto.RowVersion);

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                try
                {
                    _unitOfWork.Rollback();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Rollback failed: {ex.Message}", ex);
                }
                throw;
            }
        }

        void IAccommodationCommand.AddReview(int accommodationId, int bookingId, CreateReviewDto createReviewDto)
        {
            // Load
            var accommodation = _repository.GetAccommodation(accommodationId);
            // Do
            var booking = accommodation.Bookings.Single(b => b.Id == bookingId);
            booking.AddReview(createReviewDto.Rating, createReviewDto.Comment, createReviewDto.Date , createReviewDto.BookingId);
            // Save
            _repository.AddReview(booking);
        }
    }
}

using BookMyHome.Application.Command.CommandDto.Accommodation;
using BookMyHome.Application.Command.CommandDto.Booking;
using BookMyHome.Application.Command.CommandDto.Review;
using BookMyHome.Application.Command.Interfaces;
using BookMyHome.Application.Helpers;
using BookMyHome.Application.RepositoryInterface;
using BookMyHome.Domain.Entity;
using BookMyHome.Domain.Values;

namespace BookMyHome.Application.Command
{
    public class AccommodationCommand : IAccommodationCommand
    {
        // Fix
        private readonly IAccommodationRepository _repository;
        private readonly IServiceProvider _serviceProvider;
        private readonly IHostRepository _hostRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccommodationCommand(IAccommodationRepository accommodationRepository, IServiceProvider serviceProvider, IHostRepository hostRepository, IUnitOfWork unitOfWork)
        {
            _repository = accommodationRepository;
            _serviceProvider = serviceProvider;
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
                var address = Address.Create(createAccommodationDto.Street, createAccommodationDto.Building, createAccommodationDto.ZipCode, createAccommodationDto.City, _serviceProvider);
                var accommodation = Accommodation.Create(host, address);
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
                accommodation.CreateBooking(bookingDto.StartDate, bookingDto.EndDate, bookingDto.GuestId);
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

        void IAccommodationCommand.AddReview(CreateReviewDto createReviewDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                // Load
                var accommodation = _repository.GetAccommodation(createReviewDto.AccommodationId);
                // Do
                var booking = accommodation.AddReview(createReviewDto.BookingId, new Review(createReviewDto.Rating, createReviewDto.Comment));
                // Save
                _repository.UpdateBooking(booking, createReviewDto.RowVersion);

                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception($"Rollback failed: {ex.Message}", ex);
            }
        }
    }
}

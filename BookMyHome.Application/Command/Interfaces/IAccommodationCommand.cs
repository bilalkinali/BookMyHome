using BookMyHome.Application.Command.CommandDto.Accommodation;
using BookMyHome.Application.Command.CommandDto.Booking;
using BookMyHome.Application.Command.CommandDto.Review;

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
        void AddReview(int accommodationId, int bookingId, CreateReviewDto createReviewDto);
    }
}

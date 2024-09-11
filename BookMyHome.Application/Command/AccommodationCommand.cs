using BookMyHome.Application.Command.CommandDto.Accommodation;
using BookMyHome.Application.Command.Interfaces;
using BookMyHome.Application.Helpers;
using BookMyHome.Application.RepositoryInterface;
using BookMyHome.Domain.DomainServices;

namespace BookMyHome.Application.Command
{
    public class AccommodationCommand : IAccommodationCommand
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IAccommodationRepository _accommodationRepository;
        private readonly IBookingDomainService _domainService;
        private readonly IUnitOfWork _unitOfWork;

        public AccommodationCommand(IBookingRepository bookingRepository, IAccommodationRepository accommodationRepository, IBookingDomainService domainService, IUnitOfWork unitOfWork)
        {
            _bookingRepository = bookingRepository;
            _accommodationRepository = accommodationRepository;
            _domainService = domainService;
            _unitOfWork = unitOfWork;
        }
        void IAccommodationCommand.CreateAccommodation(CreateAccommodationDto createAccommodationDto)
        {
            throw new NotImplementedException();
        }

        void IAccommodationCommand.DeleteAccommodation(DeleteAccommodationDto deleteAccommodationDto)
        {
            throw new NotImplementedException();
        }

        void IAccommodationCommand.UpdateAccommodation(UpdateAccommodationDto updateAccommodationDto)
        {
            throw new NotImplementedException();
        }
    }
}

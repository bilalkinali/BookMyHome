using BookMyHome.Application.Command.CommandDto.Accommodation;
using BookMyHome.Application.Command.Interfaces;
using BookMyHome.Application.Helpers;
using BookMyHome.Application.RepositoryInterface;
using BookMyHome.Domain.DomainServices;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.Command
{
    public class AccommodationCommand : IAccommodationCommand
    {
        // Fix
        private readonly IAccommodationRepository _accommodationRepository;
        private readonly IHostRepository _hostRepository;

        public AccommodationCommand(IAccommodationRepository accommodationRepository, IHostRepository hostRepository)
        {
            _accommodationRepository = accommodationRepository;
            _hostRepository = hostRepository;
        }
        void IAccommodationCommand.CreateAccommodation(CreateAccommodationDto createAccommodationDto)
        {
            // Load
            var host = _hostRepository.GetHost(createAccommodationDto.HostId);
            // Do
            var accommodation = Accommodation.Create(createAccommodationDto.Price, host);
            // Save
            _accommodationRepository.AddAccommodation(accommodation);
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

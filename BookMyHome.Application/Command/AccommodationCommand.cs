using BookMyHome.Application.Command.CommandDto.Accommodation;
using BookMyHome.Application.Command.Interfaces;
using BookMyHome.Application.Helpers;
using BookMyHome.Application.RepositoryInterface;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.Command
{
    public class AccommodationCommand : IAccommodationCommand
    {
        // Fix
        private readonly IAccommodationRepository _accommodationRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccommodationCommand(IAccommodationRepository accommodationRepository, IHostRepository hostRepository, IUnitOfWork unitOfWork)
        {
            _accommodationRepository = accommodationRepository;
            _hostRepository = hostRepository;
            _unitOfWork = unitOfWork;
        }
        void IAccommodationCommand.CreateAccommodation(CreateAccommodationDto createAccommodationDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                // Load
                var host = _hostRepository.GetHost(createAccommodationDto.HostId);
                // Do
                var accommodation = Accommodation.Create(createAccommodationDto.Price, host);
                // Save
                _accommodationRepository.AddAccommodation(accommodation);

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        void IAccommodationCommand.UpdateAccommodation(UpdateAccommodationDto updateAccommodationDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                // Load
                var accommodation = _accommodationRepository.GetAccommodation(updateAccommodationDto.Id);
                // Do
                accommodation.Update(updateAccommodationDto.Price);
                // Save
                _accommodationRepository.UpdateAccommodation(accommodation, updateAccommodationDto.RowVersion);

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        void IAccommodationCommand.DeleteAccommodation(DeleteAccommodationDto deleteAccommodationDto)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                // Load
                var accommodation = _accommodationRepository.GetAccommodation(deleteAccommodationDto.Id);
                //Do & Save
                _accommodationRepository.DeleteAccommodation(accommodation, deleteAccommodationDto.RowVersion);

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}

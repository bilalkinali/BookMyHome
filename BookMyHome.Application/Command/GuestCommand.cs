using BookMyHome.Application.Command.CommandDto.Guest;
using BookMyHome.Application.Command.Interfaces;
using BookMyHome.Application.RepositoryInterface;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.Command
{
    public class GuestCommand : IGuestCommand
    {
        private readonly IGuestRepository _repository;

        public GuestCommand(IGuestRepository repository)
        {
            _repository = repository;
        }

        void IGuestCommand.CreateGuest(CreateGuestDto createGuestDto)
        {
            var guest = Guest.Create();

            _repository.Add(guest);
        }
    }
}

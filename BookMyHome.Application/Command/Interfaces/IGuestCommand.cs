using BookMyHome.Application.Command.CommandDto.Guest;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.Command.Interfaces
{
    public interface IGuestCommand
    {
        void CreateGuest(CreateGuestDto createGuestDto);
    }
}

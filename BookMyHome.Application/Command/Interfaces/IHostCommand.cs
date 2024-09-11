using BookMyHome.Application.Command.CommandDto.Booking;
using BookMyHome.Application.Command.CommandDto.Host;

namespace BookMyHome.Application.Command.Interfaces
{
    public interface IHostCommand
    {
        void CreateHost(CreateHostDto createHostDto);
        //void UpdateHost(UpdateHostDto updateHostDto);
        //void DeleteHost(DeleteHostDto deleteHostDto);
    }
}

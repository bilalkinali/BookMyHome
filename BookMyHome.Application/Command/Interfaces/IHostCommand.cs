using BookMyHome.Application.Command.CommandDto.Host;

namespace BookMyHome.Application.Command.Interfaces
{
    public interface IHostCommand
    {
        void CreateHost(CreateHostDto createHostDto);
    }
}

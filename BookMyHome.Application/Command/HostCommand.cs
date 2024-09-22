using BookMyHome.Application.Command.CommandDto.Host;
using BookMyHome.Application.Command.Interfaces;
using BookMyHome.Application.RepositoryInterface;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.Command
{
    public class HostCommand : IHostCommand
    {
        private readonly IHostRepository _repository;
        public HostCommand(IHostRepository repository)
        {
            _repository = repository;
        }
        void IHostCommand.CreateHost(CreateHostDto createHostDto)
        {
            var host = Host.Create();

            _repository.Add(host);
        }
    }
}

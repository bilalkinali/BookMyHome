namespace BookMyHome.Application.Query
{
    public interface IHostQuery
    {
        HostDto GetHost(int id);
        IEnumerable<HostDto> GetHosts();
    }

    public class HostDto
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}

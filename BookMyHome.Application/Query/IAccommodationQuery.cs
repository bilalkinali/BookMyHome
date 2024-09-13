using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.Query
{
    public interface IAccommodationQuery
    {
        AccommodationDto GetAccommodation(int id);
        IEnumerable<AccommodationDto> GetAccommodations();
    }

    public class AccommodationDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public Host Host { get; set; }
        public byte[] RowVersion { get; set; }
    }
}

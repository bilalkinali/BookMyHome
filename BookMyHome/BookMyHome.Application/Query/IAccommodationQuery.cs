using BookMyHome.Application.Query.QueryDto;

namespace BookMyHome.Application.Query;

public interface IAccommodationQuery
{
    AccommodationDto GetAccommodation(int id);
    IEnumerable<AccommodationDto> GetAccommodations();
}
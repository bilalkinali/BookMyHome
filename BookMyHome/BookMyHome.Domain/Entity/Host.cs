namespace BookMyHome.Domain.Entity;

public class Host : DomainEntity
{
    private readonly List<Accommodation>? _accommodations;

    protected Host() {}

    public IReadOnlyCollection<Accommodation> Accommodations => _accommodations ?? [];

    public static Host Create()
    {
        return new Host();
    }
}
namespace BookMyHome.Domain.Entity
{
    public class Host : DomainEntity
    {
        private readonly List<Accommodation>? _accommodations;

        public IReadOnlyCollection<Accommodation> Accommodations => _accommodations ?? [];

        protected Host() {}

        public static Host Create()
        {
            return new Host();
        }
    }
}

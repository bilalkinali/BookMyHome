namespace BookMyHome.Domain.Entity
{
    public class Host : DomainEntity
    {
        public IEnumerable<Accommodation>? Accommodations { get; protected set; }

        protected Host() {}

        public static Host Create()
        {
            return new Host();
        }
    }
}

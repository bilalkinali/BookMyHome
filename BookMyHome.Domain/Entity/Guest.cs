namespace BookMyHome.Domain.Entity
{
    public class Guest : DomainEntity
    {
        public IReadOnlyCollection<Booking> Bookings => _bookings;

        private readonly List<Booking> _bookings = new List<Booking>();

        protected Guest () {}

        public static Guest Create()
        {
            return new Guest();
        }
    }
}

namespace BookMyHome.Domain.Entity
{
    public class Accommodation : DomainEntity
    {
        public double Price { get; protected set; }
        public Host Host { get; protected set; }
        public IReadOnlyCollection<Booking> Bookings => _bookings;

        private readonly List<Booking> _bookings = new List<Booking>();

        protected Accommodation () {}

        protected Accommodation(double price, Host host)
        {
            Price = price;
            Host = host;

            AssurePriceOverZero();
        }

        public static Accommodation Create(double price, Host host)
        {
            return new Accommodation(price, host);
        }

        public void Update(double price)
        {
            Price = price;

            AssurePriceOverZero();
        }

        protected void AssurePriceOverZero()
        {
            if (!(Price > 0))
            {
                throw new ArgumentException("Prisen skal være over 0");
            }
        }

        // Booking

        public void CreateBooking(DateOnly startDate, DateOnly endDate)
        {
            var booking = Booking.Create(startDate, endDate, Bookings);
            _bookings.Add(booking);
        }

        public Booking UpdateBooking(int bookingId, DateOnly startDate, DateOnly endDate)
        {
            var booking = Bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking == null) throw new ArgumentException("Booking not found");
            booking.Update(startDate, endDate, Bookings);
            return booking;
        }
        
        // Review

        public Booking AddReview(int bookingId, double rating, string comment)
        {
            var booking = Bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking == null) throw new ArgumentException("Booking not found");
            booking.AddReview(rating, comment);
            return booking;
        }
    }
}

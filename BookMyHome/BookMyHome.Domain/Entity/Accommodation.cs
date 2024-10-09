using BookMyHome.Domain.Values;

namespace BookMyHome.Domain.Entity
{
    public class Accommodation : DomainEntity
    {
        public Host Host { get; protected set; }
        public Address Address { get; protected set; }
        public IReadOnlyCollection<Booking> Bookings => _bookings;

        private readonly List<Booking> _bookings = new List<Booking>();

        protected Accommodation () {}

        protected Accommodation(Host host, Address address)
        {
            Host = host;
            Address = address;
        }

        public static Accommodation Create(Host host, Address address)
        {
            return new Accommodation(host, address);
        }

        public void Update(double price)
        {

        }

        // Booking

        public void CreateBooking(DateOnly startDate, DateOnly endDate, int guestId)
        {
            var booking = Booking.Create(startDate, endDate, Bookings, guestId);
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
        public Booking AddReview(int bookingId, Review review)
        {
            var booking = Bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking == null) throw new ArgumentException("Booking not found");
            booking.AddReview(review);
            return booking;

        }
    }
}

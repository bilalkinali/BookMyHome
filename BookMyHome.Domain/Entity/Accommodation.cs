﻿namespace BookMyHome.Domain.Entity
{
    public class Accommodation : DomainEntity
    {
        public double Price { get; protected set; }
        public Host Host { get; protected set; }
        public IReadOnlyCollection<Booking> Bookings => _bookings;
        public IReadOnlyCollection<Review> Reviews => _reviews;

        private readonly List<Booking> _bookings = new List<Booking>();
        private readonly List<Review> _reviews = new List<Review>();

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

        public void CreateReview(int bookingId, double rating, string comment)
        {
            var booking = Bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking == null) throw new ArgumentException("Booking not found");
            var review = booking.CreateReview(rating, comment);
            _reviews.Add(review);
        }
    }
}

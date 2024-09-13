namespace BookMyHome.Domain.Entity
{
    public class Accommodation : DomainEntity
    {
        public double Price { get; protected set; }
        public List<Booking> Bookings { get; protected set; }
        public Host Host { get; protected set; }

        protected Accommodation () {}

        private Accommodation(double price, Host host)
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
    }
}

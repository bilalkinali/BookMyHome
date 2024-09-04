using BookMyHome.Domain.DomainServices;

namespace BookMyHome.Domain.Entity
{
    public class Booking
    {
        public int Id { get; protected set; }
        public DateOnly StartDate { get; protected set; }
        public DateOnly EndDate { get; protected set; }

        protected Booking() { }

        private Booking(DateOnly startDate, DateOnly endDate, IBookingDomainService bookingDomainService)
        {
            StartDate = startDate;
            EndDate = endDate;

            StartDateBeforeEndDate();

            StartDateInFuture(DateOnly.FromDateTime(DateTime.Now));

            IsOverlapping(bookingDomainService.GetOtherBookings(this));
        }


        protected void StartDateBeforeEndDate()
        {
            if (StartDate >= EndDate)
                throw new ArgumentException("StartDato skal være før SlutDato");
        }

        protected void StartDateInFuture(DateOnly now) 
        {
            if (StartDate <= now)
                throw new ArgumentException("StartDato skal være i fremtiden"); 
        }

        protected void IsOverlapping(IEnumerable<Booking> otherBookings)
        {
            if (otherBookings.Any(other =>
                    (EndDate <= other.EndDate && EndDate >= other.StartDate) ||
                    (StartDate >= other.StartDate && StartDate <= other.EndDate) || 
                    (StartDate <= other.StartDate && EndDate >= other.EndDate)))
                throw new Exception("Booking overlapper med en anden booking");
        }

        /// <summary>
        ///     Booking factory method
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="bookingDomainService"></param>
        /// <returns></returns>
        public static Booking Create(DateOnly startDate, DateOnly endDate, IBookingDomainService bookingDomainService)
        {
            return new Booking(startDate, endDate, bookingDomainService);
        }

        public void Update(DateOnly startDate, DateOnly endDate, IBookingDomainService domainService)
        {
            StartDate = startDate;
            EndDate = endDate;

            // Mulige andre tjeks ved update
            StartDateBeforeEndDate();
            StartDateInFuture(DateOnly.FromDateTime(DateTime.Now));
            IsOverlapping(domainService.GetOtherBookings(this));
        }
    }
}

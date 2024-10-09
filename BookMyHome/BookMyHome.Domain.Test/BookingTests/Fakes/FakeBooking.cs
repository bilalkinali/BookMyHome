using BookMyHome.Domain.Entity;

namespace BookMyHome.Domain.Test.BookingTests.Fakes
{
    public class FakeBooking : Booking
    {
        public FakeBooking(DateOnly startDate, DateOnly endDate) : base()
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public new void StartDateBeforeEndDate()
        {
            base.StartDateBeforeEndDate();
        }

        public new void StartDateInFuture(DateOnly now)
        {
            base.StartDateInFuture(now);
        }

        public new void IsOverlapping(IEnumerable<Booking> otherBookings)
        {
            base.IsOverlapping(otherBookings);
        }
    }
}

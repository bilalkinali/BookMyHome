namespace BookMyHome.Domain.Entity
{
    public class Booking
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; protected set; }
        public DateOnly EndDate { get; protected set; }

        protected Booking() { }

        private Booking(DateOnly startDate, DateOnly endDate)
        {
            StartDate = startDate;
            EndDate = endDate;

            StartDateBeforeEndDate();

            StartDateInFuture(DateOnly.FromDateTime(DateTime.Now));

            NoOverlapping(this);
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

        protected void NoOverlapping(Booking booking)
        {
            throw new ArgumentException();
        }
    }
}

namespace BookMyHome.Domain.Entity;

public class Booking : DomainEntity
{
    protected Booking()
    {
    }

    private Booking(DateOnly startDate, DateOnly endDate, IEnumerable<Booking> existingBookings)
    {
        StartDate = startDate;
        EndDate = endDate;

        StartDateBeforeEndDate();

        StartDateInFuture(DateOnly.FromDateTime(DateTime.Now));

        IsOverlapping(existingBookings);
    }

    public DateOnly StartDate { get; protected set; }
    public DateOnly EndDate { get; protected set; }
    public Review? Review { get; protected set; }

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

    protected void IsOverlapping(IEnumerable<Booking> existingBookings)
    {
        var otherBookings = existingBookings.Where(b => b != this);
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
    /// <param name="accommodation"></param>
    /// <param name="bookingDomainService"></param>
    /// <returns></returns>
    


    public static Booking Create(DateOnly startDate, DateOnly endDate, IEnumerable<Booking> existingBookings)
    {
        return new Booking(startDate, endDate, existingBookings);
    }

    public void Update(DateOnly startDate, DateOnly endDate, IEnumerable<Booking> existingBookings)
    {
        StartDate = startDate;
        EndDate = endDate;

        // Mulige andre tjeks ved update
        StartDateBeforeEndDate();
        StartDateInFuture(DateOnly.FromDateTime(DateTime.Now));
        IsOverlapping(existingBookings);
    }

    // Review

    protected void IsReviewable(DateOnly date)
    {
        if (EndDate > date)
            throw new ArgumentException("EndDate skal være i fortiden");
    }

    public void AddReview(double rating, string comment, DateOnly date, int bookingId)
    {
        IsReviewable(date);
        var test = Review.Create(rating, comment, bookingId);
        Review = test;
    }
}
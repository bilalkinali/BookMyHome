namespace BookMyHome.Domain.Entity
{
    public class Review
    {
        public Review() {}

        public int Id { get; protected set; }
        public double Rating { get; protected set; }
        public string? Comment { get; protected set; }
        public DateOnly Date { get; protected set; }

        private Review(double rating, string comment, DateOnly bookingStartDate)
        {
            Rating = rating;
            Comment = comment;
            Date = DateOnly.FromDateTime(DateTime.Now);

            IsReviewable(bookingStartDate);
        }

        public static Review Create(double rating, string comment, DateOnly bookingStartDate)
        {
            return new Review(rating, comment, bookingStartDate);
        }

        private void IsReviewable(DateOnly bookingStartDate)
        {
            if (bookingStartDate > Date)
                throw new ArgumentException("BookingStartDate skal være i fortiden");
        }
    }

    
}

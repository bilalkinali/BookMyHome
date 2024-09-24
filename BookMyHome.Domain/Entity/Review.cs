namespace BookMyHome.Domain.Entity
{
    public class Review
    {
        public Review() {}

        public double Rating { get; protected set; }
        public string? Comment { get; protected set; }
        public DateOnly Date { get; protected set; }
        public int BookingId { get; protected set; }

        private Review(double rating, string comment, int bookingId)
        {
            Rating = rating;
            Comment = comment;
            Date = DateOnly.FromDateTime(DateTime.Now);
            BookingId = bookingId;
        }

        public static Review Create(double rating, string comment, int bookingId)
        {
            return new Review(rating, comment, bookingId);
        }
    }

    
}

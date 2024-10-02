using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyHome.Domain.Entity
{
    [ComplexType]
    public record Review
    {
        protected Review() {}
        public double Rating { get; private set; }
        public string? Comment { get; private set; }
        public DateOnly Date { get; }

        public Review(double rating, string comment)
        {
            Rating = rating;
            Comment = comment;
            Date = DateOnly.FromDateTime(DateTime.Now);
        }

        public static Review Create(double rating, string comment)
        {
            return new Review(rating, comment);
        }

        //private void IsReviewable(DateOnly bookingStartDate)
        //{
        //    if (bookingStartDate > Date)
        //        throw new ArgumentException("BookingStartDate skal være i fortiden");
        //}
    }

    
}

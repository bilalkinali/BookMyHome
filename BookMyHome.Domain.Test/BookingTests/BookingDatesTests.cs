using BookMyHome.Domain.Test.BookingTests.Fakes;

namespace BookMyHome.Domain.Test.BookingTests
{
    public class BookingDatesTests
    {
        [Theory]
        [InlineData("2024-08-01", "2024-08-03")]
        [InlineData("2024-08-01", "2024-08-20")]
        [InlineData("2024-08-01", "2025-04-03")]
        public void Given_Startdate_is_future__Then_Return_Void(string now, string startDate)
        {
            // Arrange
            var sut = new FakeBooking(DateOnly.Parse(startDate), DateOnly.MaxValue);

            // Act & Assert
            sut.StartDateInFuture(DateOnly.Parse(now));
        }

        [Theory]
        [InlineData("2024-08-02", "2024-05-23")]
        [InlineData("2024-08-02", "2024-07-23")]
        [InlineData("2024-08-02", "2024-08-02")]
        public void Given_Booking_is_Past_or_Today__Then_Exception(string now, string startDate)
        {
            // Arrange
            var sut = new FakeBooking(DateOnly.Parse(startDate), DateOnly.MaxValue);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => sut.StartDateInFuture(DateOnly.Parse(now)));
        }

        [Theory]
        [InlineData("2024-08-01", "2024-08-02")]
        [InlineData("2024-08-01", "2024-08-20")]
        [InlineData("2024-08-01", "2025-04-03")]
        public void Given_Startdate_before_EndDate__Then_Void(string startDate, string endDate)
        {
            // Arrange
            var sut = new FakeBooking(DateOnly.Parse(startDate), DateOnly.Parse(endDate));

            // Act & Assert
            sut.StartDateBeforeEndDate();
        }

        [Theory]
        [InlineData("2025-07-02", "2024-08-02")]
        [InlineData("2024-08-03", "2024-08-02")]
        [InlineData("2024-12-02", "2024-08-02")]
        public void Given_Startdate_after_EndDate__Then_Exception(string startDate, string endDate)
        {
            // Arrange
            var sut = new FakeBooking(DateOnly.Parse(startDate), DateOnly.Parse(endDate));

            // Act & Assert
            Assert.Throws<ArgumentException>(() => sut.StartDateBeforeEndDate());
        }
    }
}

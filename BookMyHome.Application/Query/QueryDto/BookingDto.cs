﻿namespace BookMyHome.Application.Query.QueryDto;

public class BookingDto
{
    public int Id { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int AccommodationId { get; set; }
    public byte[] RowVersion { get; set; } = null!;
}
﻿namespace BookMyHome.Application.Command.CommandDto.Booking;

public record DeleteBookingDto
{
    public int Id { get; set; }
    public int AccommodationId { get; set; }
    public byte[] RowVersion { get; set; }
}
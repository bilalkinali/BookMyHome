using BookMyHome.Application;
using BookMyHome.Application.Command.CommandDto.Accommodation;
using BookMyHome.Application.Command.CommandDto.Booking;
using BookMyHome.Application.Command.CommandDto.Host;
using BookMyHome.Application.Command.Interfaces;
using BookMyHome.Application.Query;
using BookMyHome.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application and Infrastructure services
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-8.0&tabs=visual-studio
app.MapGet("/hello", () => "Hello World");

// Booking
app.MapGet("/booking", (IBookingQuery query) => query.GetBookings());
app.MapGet("/accommodation/{id}/booking", (int id, IBookingQuery query) => query.GetBookingsForAccommodation(id));
app.MapGet("/accommodation/{accommodationId}/booking/{bookingId}", (int accommodationId, int bookingId, IBookingQuery query) => query.GetBooking(accommodationId, bookingId));
app.MapPost("/accommodation/booking", (CreateBookingDto booking, IAccommodationCommand command) => command.CreateBooking(booking));
app.MapPut("/accommodation/booking", (UpdateBookingDto booking, IAccommodationCommand command) => command.UpdateBooking(booking));

//app.MapGet("/booking/{id}", (int id, IBookingQuery query) => query.GetBooking(id));
//app.MapPost("/booking", (CreateBookingDto booking, IBookingCommand command) => command.CreateBooking(booking));
//app.MapPut("/booking", (UpdateBookingDto booking, IBookingCommand command) => command.UpdateBooking(booking));
//app.MapDelete("/booking", ([FromBody] DeleteBookingDto booking, IBookingCommand command) => command.DeleteBooking(booking));

// Accommodation
app.MapGet("/accommodation", (IAccommodationQuery query) => query.GetAccommodations());
app.MapGet("/accommodation/{id}", (int id, IAccommodationQuery query) => query.GetAccommodation(id));
app.MapPost("/accommodation", (CreateAccommodationDto accommodation, IAccommodationCommand command) => command.Create(accommodation));
app.MapPut("/accommodation", (UpdateAccommodationDto accommodation, IAccommodationCommand command) => command.Update(accommodation));
app.MapDelete("/accommodation", ([FromBody] DeleteAccommodationDto accommodation, IAccommodationCommand command) => command.Delete(accommodation));

// Host
//app.MapGet("/host", (IHostQuery query) => query.GetHosts());
//app.MapGet("/host/{id}", (int id, IHostQuery query) => query.GetHost(id));
app.MapGet("/host/{id}/accommodation", (int id, IHostQuery query) => query.GetAccommodations(id));
app.MapPost("/host", (CreateHostDto host, IHostCommand command) => command.CreateHost(host));

app.Run();

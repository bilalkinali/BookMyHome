﻿using BookMyHome.Application.Command.CommandDto.Booking;
using BookMyHome.Application.Helpers;
using BookMyHome.Application.RepositoryInterface;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Application.Command;

public class BookingCommand //: IBookingCommand
{
    //private readonly IAccommodationRepository _accommodationRepository;
    //private readonly IBookingRepository _bookingRepository;
    //private readonly IBookingDomainService _domainService;
    //private readonly IUnitOfWork _unitOfWork;

    //public BookingCommand(IBookingRepository bookingRepository, IAccommodationRepository accommodationRepository,
    //    IUnitOfWork unitOfWork)
    //{
    //    _bookingRepository = bookingRepository;
    //    _accommodationRepository = accommodationRepository;
    //    _unitOfWork = unitOfWork;
    //}

    //void IBookingCommand.CreateBooking(CreateBookingDto createBookingDto)
    //{
    //    try
    //    {
    //        // Load
    //        var accommodation = _accommodationRepository.GetAccommodation(createBookingDto.AccommodationId);

    //        _unitOfWork.BeginTransaction(); // Transaction for phantom read

    //        // Do
    //        var booking = Booking.Create(createBookingDto.StartDate, createBookingDto.EndDate);
    //        // Save
    //        _bookingRepository.AddBooking(booking);

    //        _unitOfWork.Commit();
    //    }
    //    catch (Exception)
    //    {
    //        _unitOfWork.Rollback();
    //        throw;
    //    }
    //}

    //void IBookingCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
    //{
    //    try
    //    {
    //        _unitOfWork.BeginTransaction();

    //        // Load
    //        var booking = _bookingRepository.GetBooking(updateBookingDto.Id);
    //        // Do
    //        booking.Update(updateBookingDto.StartDate, updateBookingDto.EndDate, _domainService);
    //        // Save
    //        _bookingRepository.UpdateBooking(booking, updateBookingDto.RowVersion);

    //        _unitOfWork.Commit();
    //    }
    //    catch (Exception)
    //    {
    //        _unitOfWork.Rollback();
    //        throw;
    //    }
    //}

    //void IBookingCommand.DeleteBooking(DeleteBookingDto deleteBookingDto)
    //{
    //    try
    //    {
    //        _unitOfWork.BeginTransaction();

    //        // Load            
    //        var booking = _bookingRepository.GetBooking(deleteBookingDto.Id);
    //        // Do & Save
    //        _bookingRepository.DeleteBooking(booking, deleteBookingDto.RowVersion);

    //        _unitOfWork.Commit();
    //    }
    //    catch (Exception)
    //    {
    //        _unitOfWork.Rollback();
    //        throw;
    //    }
    //}
}
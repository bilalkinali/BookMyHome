using BookMyHome.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application
{
    public interface IBookingRepository
    {
        void AddBooking(Booking booking);
        Booking GetBooking(int id);
        void UpdateBooking(Booking booking, byte[] rowversion);
    }
}

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
        public void AddBooking(Booking booking);
        public Booking GetBooking(int id);
        public void UpdateBooking(Booking booking);
    }
}

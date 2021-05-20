using BookingsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingsAPI.Repository
{
    public interface IBookingRepo
    {
        public int Book(int userId, int flightId, int seats);
        public int Cancel(int bookingId);
        public IEnumerable<Bookings> GetBookings(int userId);

        public Bookings GetBookingById(int userid);


        public IEnumerable<Flights> FindByLocation(string fromlocation, string tolocation);
       
    }
}

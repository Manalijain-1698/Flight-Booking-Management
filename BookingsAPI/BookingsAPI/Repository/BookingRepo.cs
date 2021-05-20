using BookingsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingsAPI.Repository
{
    public class BookingRepo : IBookingRepo
    {
        private FlightManagementSystemContext _context;

        public BookingRepo(FlightManagementSystemContext context)
        {
            this._context = context;
        }
        public int Book(int userId, int flightId, int seats)
        {
            int res = 0;
            var flight = _context.Flights.Find(flightId);
            if (flight != null)
            {
                double price = seats * (double)flight.Price;
                Bookings obj = new Bookings() { Userid = userId, Flightid = flightId, NoOfSeats = seats, Totalprice = (decimal)price };
                _context.Bookings.Add(obj);
                _context.SaveChanges();

                flight.AvailableSeats = flight.AvailableSeats - seats;
                _context.Flights.Update(flight);
                res = _context.SaveChanges();

            }
            return res;
        }

        public int Cancel(int bookingId)
        {
            int res = 0;
            var booking = _context.Bookings.Find(bookingId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
                var flight = _context.Flights.FirstOrDefault(f => f.Flightid == booking.Flightid);
                flight.AvailableSeats = flight.AvailableSeats + booking.NoOfSeats;
                _context.Flights.Update(flight);
                res = _context.SaveChanges();
            }
            return res;
        }

        public IEnumerable<Flights> FindByLocation(string fromlocation, string tolocation)
        {
            var flights = from flight in _context.Flights where flight.FromLocation == fromlocation && flight.ToLocation == tolocation select flight;
            return flights.ToList();
        }

        public Bookings GetBookingById(int userid)
        {
            Bookings Bookingdetails = _context.Bookings.FirstOrDefault(f => f.Userid == userid);
            return Bookingdetails;
        }

        public IEnumerable<Bookings> GetBookings(int userId)
        {
            var tickets = from booking in _context.Bookings where booking.Userid == userId select booking;
            return tickets.ToList();
        }
    }
}

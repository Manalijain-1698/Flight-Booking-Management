using FlightsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsAPI.Repository
{
    public class FlightRepo : IFlightRepo
    {
        public FlightManagementSystemContext _context;
        public FlightRepo(FlightManagementSystemContext context)
        {
            this._context = context;
        }

        public int AddFlight(Flights flight)
        {
            _context.Flights.AddAsync(flight);
            return _context.SaveChanges();
        }

        public int DeleteFlight(int id)
        {
            Flights flight = _context.Flights.FirstOrDefault(f => f.Flightid == id);
            _context.Flights.Remove(flight);
            return _context.SaveChanges();
        }

        public IEnumerable<Flights> FindByLocation(string fromlocation, string tolocation)
        {
            var flightdetails = (from flight in _context.Flights where flight.FromLocation == fromlocation && flight.ToLocation == tolocation select flight);
            return flightdetails.ToList();

        }

        public IEnumerable<Flights> GetAllflights()
        {
            var flightlist = from flight in _context.Flights select flight;
            return flightlist.ToList();

        }

        public Flights GetById(int FlightId)
        {
            Flights flightdetails = _context.Flights.FirstOrDefault(f => f.Flightid == FlightId);
            return flightdetails;
        }

        public async Task<Flights> UpdateFlight(int id, Flights newflight)
        {
            Flights flight = await _context.Flights.FindAsync(id);
            flight.Flightid = newflight.Flightid;
            flight.Airlineid = newflight.Airlineid;
            flight.AvailableSeats = newflight.AvailableSeats;
            flight.ToLocation = newflight.ToLocation;
            flight.FromLocation = newflight.FromLocation;
            flight.Date = newflight.Date;
            flight.Price = newflight.Price;
            flight.ArrivalTime = newflight.ArrivalTime;
            flight.DepartureTime = newflight.DepartureTime;
            await _context.SaveChangesAsync();
            return flight;
        }
    }
}

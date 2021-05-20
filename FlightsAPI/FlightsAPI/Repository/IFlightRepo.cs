using FlightsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsAPI.Repository
{
    public interface IFlightRepo
    {
        public IEnumerable<Flights> GetAllflights();
        public Flights GetById(int FlightId);
        public IEnumerable<Flights> FindByLocation(string fromlocation, string tolocation);
        public int AddFlight(Flights flight);
        Task<Flights> UpdateFlight(int id, Flights flightdetails);
        public int DeleteFlight(int id);

    }
}

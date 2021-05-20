using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookingsAPI.Models
{
    public partial class Flights
    {
        public Flights()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int Flightid { get; set; }
        public int? Airlineid { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public int? Duration { get; set; }
        public DateTime? Date { get; set; }
        public int? AvailableSeats { get; set; }
        public decimal? Price { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }

        public virtual Airlines Airline { get; set; }
        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}

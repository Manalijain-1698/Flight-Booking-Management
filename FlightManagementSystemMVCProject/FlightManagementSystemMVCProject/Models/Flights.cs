using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementSystemMVCProject.Models
{
    public class Flights
    {
        [Display(Name = "Flight Id")]
        public int Flightid { get; set; }

        [Display(Name = "Airlines Id")]
        public int? Airlineid { get; set; }

        [Display(Name = "From Location")]
        public string FromLocation { get; set; }

        [Display(Name = "To Location")]
        public string ToLocation { get; set; }

        [Display(Name = "Duration (Hrs)")]
        public int? Duration { get; set; }

        [Display(Name = "Date")]
        public DateTime? Date { get; set; }

        [Display(Name = "Available Seats")]
        public int? AvailableSeats { get; set; }

        [Display(Name = "Price (Rs)")]
        public decimal? Price { get; set; }

        [Display(Name = "Arrival Time")]
        public string ArrivalTime { get; set; }

        [Display(Name = "Departure Time")]
        public string DepartureTime { get; set; }

    }
}

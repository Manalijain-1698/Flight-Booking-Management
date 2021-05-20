using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementSystemMVCProject.Models
{
    public class Bookings
    {
        [Display(Name ="Booking Id")]
        public int Bookingid { get; set; }

        [Display(Name = "User Id")]
        public int? Userid { get; set; }

        [Display(Name = "Flight Id")]
        public int? Flightid { get; set; }

        [Display(Name = "No of Seats")]
        public int? NoOfSeats { get; set; }

        [Display(Name = "Total Price")]
        public decimal? Totalprice { get; set; }
    }
}

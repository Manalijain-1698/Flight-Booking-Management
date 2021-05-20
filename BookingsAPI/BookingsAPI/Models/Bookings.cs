using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookingsAPI.Models
{
    public partial class Bookings
    {
        public int Bookingid { get; set; }
        public int? Userid { get; set; }
        public int? Flightid { get; set; }
        public int? NoOfSeats { get; set; }
        public decimal? Totalprice { get; set; }

        public virtual Flights Flight { get; set; }
        public virtual Userdetails User { get; set; }
    }
}

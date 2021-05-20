using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LoginAPI.Models
{
    public partial class Airlines
    {
        public Airlines()
        {
            Flights = new HashSet<Flights>();
        }

        public int Airlinesid { get; set; }
        public string Airlinename { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Flights> Flights { get; set; }
    }
}

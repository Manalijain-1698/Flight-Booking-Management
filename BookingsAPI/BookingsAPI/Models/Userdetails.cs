using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookingsAPI.Models
{
    public partial class Userdetails
    {
        public Userdetails()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int Userid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Age { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}

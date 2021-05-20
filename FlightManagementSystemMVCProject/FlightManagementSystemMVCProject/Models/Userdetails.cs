using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementSystemMVCProject.Models
{
    public class Userdetails
    {
        public int Userid { get; set; }
        [Display(Name ="Username")]
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Age { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}

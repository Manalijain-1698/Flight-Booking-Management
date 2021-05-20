using FlightManagementSystemMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FlightManagementSystemMVCProject.Controllers
{
    public class BookingController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(BookingController));

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ChooseLocation()
        {
            
            return View();
            
        }

        [HttpPost]
        public async Task<IActionResult> ChooseLocation(string fromlocation, string tolocation)
        {
            _log4net.Info("Choose Location Was Called !!");
            var flightslist = new List<Flights>();

            using (var httpClient = new HttpClient())
            {
                try
                {

                    using (var response = await httpClient.GetAsync("http://localhost:46121/api/Booking/GetFlightsByLocation?fromlocation=" + fromlocation + "&tolocation=" + tolocation))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            //_log4net.Info("AuditCheckList API with Audit type  " + AuditType + "was called");
                            ViewBag.message = "Success";
                            var Response = response.Content.ReadAsStringAsync().Result;
                            flightslist = JsonConvert.DeserializeObject<List<Flights>>(Response);
                        }
                    }
                    TempData["flights"] = JsonConvert.SerializeObject(flightslist);

                }
                catch (Exception)
                {
                    ViewBag.Message = "Booking API not Loaded. Please Try Later.";
                    return View();
                }
                return RedirectToAction("ShowFlights");
            }



        }

        [HttpGet]
        public IActionResult ShowFlights()
        {
            _log4net.Info("Show Flights method Was Called !!");

            var lst = JsonConvert.DeserializeObject<List<Flights>>(TempData["flights"].ToString());

            try
            {
                if (lst.Count == 0)
                {
                    //return RedirectToAction("ChooseLocation");
                    ViewBag.message = "Flights not available";
                }

                return View(lst);
            }
            catch (Exception e)
            {
                ViewBag.message = e.Message;
            }
            return View(lst);
            
        }

        [HttpGet]
        public IActionResult BookTicket()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BookTicket(int id, int noofseats)
        {
            _log4net.Info("Book Ticket  method Was Called with id {0} !!"+id);

            int userid = (int)TempData["Userid"];
            Bookings bookings = new Bookings() { Flightid = id, NoOfSeats = noofseats,Userid=userid };

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:46121");
                var postData = httpClient.PostAsJsonAsync<Bookings>("/api/Booking/BookTicket", bookings);
                var res = postData.Result;
                if (res.IsSuccessStatusCode)
                {
                    ViewBag.message = "Booking Succesfull!";
                }
            }
            return RedirectToAction("GetBookingDetails");
        }


        [HttpGet]
        public async Task<IActionResult> GetBookingDetails()
        {
            var bookinglist = new List<Bookings>();
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:46121");
                HttpResponseMessage res = await httpclient.GetAsync("/api/Booking/GetTickets?userId="+TempData["UserId"]);
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    bookinglist = JsonConvert.DeserializeObject<List<Bookings>>(result);
                }
            }
            return View(bookinglist);
        }


        public IActionResult Logout()
        {
            _log4net.Info("Logout Was Called !!");
            return RedirectToAction("Login", "Login");
        }







    }





    


}








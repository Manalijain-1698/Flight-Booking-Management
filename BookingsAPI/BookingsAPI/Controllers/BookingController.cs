using BookingsAPI.Models;
using BookingsAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(BookingController));

        public IBookingRepo repo;
        public BookingController(IBookingRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        [Route("GetFlightsByLocation")]
        public IActionResult GetFlightsByLocation(string fromlocation, string tolocation)
        {
            _log4net.Info(" Http GetFlightsByLocation request Initiated");
            if (fromlocation == "" || tolocation == "")
            {
                return BadRequest("Invalid Location");
            }
            try
            {
                var flightlist = repo.FindByLocation(fromlocation, tolocation);
                if (flightlist != null)
                {
                    return Ok(flightlist);
                }
                else
                {
                    return BadRequest("No Flights Found");
                }
            }
            catch (Exception)
            {
                return BadRequest("Some Error in Connection , Please Try Again");
            }
        }

        [HttpPost]
        [Route("BookTicket")]
        public IActionResult BookTicket(Bookings book)
        {
            _log4net.Info(" Http BookTicket request Initiated");
            if (book.Userid == 0 || book.Flightid == 0 || book.NoOfSeats == 0)
            {
                return BadRequest("Please provide valid input");
            }

            try
            {
                var res = repo.Book((int)book.Userid, (int)book.Flightid, (int)book.NoOfSeats);
                if (res == 1)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Something went wrong");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpGet]
        [Route("GetTickets")]
        public IActionResult GetTickets(int userId)
        {
            _log4net.Info(" Http GetTicket request Initiated with id {0}"+userId);
            if (userId == 0)
            {
                return BadRequest("Provide Valid User Id");
            }
            try
            {
                var tickets = repo.GetBookings(userId);
                if (tickets != null)
                {
                    return Ok(tickets);
                }
                return BadRequest("No Booking yet");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        

        [HttpDelete]
        [Route("CancelBooking")]
        public IActionResult CancelBooking(int bookingid)
        {
            _log4net.Info(" Http CancelBooking request Initiated");
            if (bookingid == 0)
            {
                return BadRequest("Provide Correct Input");
            }
            try
            {
                var res = repo.Cancel(bookingid);
                if (res == 1)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Could not be cancelled please try again");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("GetBookingById")]

        public IActionResult GetBookingById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Enter valid Id");
            }
            try
            {
                var flightdetails = repo.GetBookingById(id);
                if (flightdetails != null)
                {
                    return Ok(flightdetails);
                }
                return BadRequest("No data available!");
            }
            catch (Exception)
            {
                return BadRequest("Error in fetching in flight details!");

            }
        }


    }
}

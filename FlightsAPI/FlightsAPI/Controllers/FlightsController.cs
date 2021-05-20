using FlightsAPI.Models;
using FlightsAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        public IFlightRepo repo;

        public FlightsController(IFlightRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("GetAllFlights")]
        public IActionResult GetAllFlights()
        {
            try
            {
                var flightlist = repo.GetAllflights();
                if (flightlist != null)
                {
                    return Ok(flightlist);
                }
                return BadRequest("No data Available!");
            }

            catch (Exception)
            {

                return BadRequest("Error in fetching in all the flights!");
            }

        }

        [HttpGet]
        [Route("GetFlightById")]

        public IActionResult GetFlightById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Enter valid Id");
            }
            try
            {
                var flightdetails = repo.GetById(id);
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

        [HttpGet]
        [Route("GetFlightsByLocation")]
        public IActionResult GetFlightsByLocation(string fromlocation,string tolocation)
        {
            try
            {
                var flightdata = repo.FindByLocation(fromlocation,tolocation);
                if (flightdata != null)
                {
                    return Ok(flightdata);
                }
                return BadRequest("No data Available!");
            }

            catch (Exception)
            {

                return BadRequest("Error in fetching in all the flights!");
            }

        }

        [HttpPost]
        [Route("AddFlight")]
        public IActionResult AddFlight([FromBody]Flights flight)
        {
            //_log4net.Info(" Http AddFlight request Initiated");
            if (flight == null)
            {
                return BadRequest();
            }
            try
            {
                int res = repo.AddFlight(flight);
                if (res == 1)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Flight couldn't be added!");
                }
            }
            catch (Exception)
            {
                return BadRequest("Error occured during adding Flight!.");
            }
        }

        [HttpPut]
        [Route("UpdateFlightDetails")]
        public async Task<IActionResult> UpdateFlightDetails(int id,Flights flightDetails)
        {
            if (id != flightDetails.Flightid)
            {
                return BadRequest();
            }


            try
            {
                //_log4net.Info("update tacos with id " + id + "method is invoked");

                await repo.UpdateFlight(id,flightDetails);
            }
            catch (Exception)
            {
                return BadRequest("Update Flight details failed!");
            }

            return NoContent();
        }


        [HttpDelete]
        [Route("DeleteFlight")]
        public IActionResult Delete(int id)
        {
            //_log4net.Info(" Http DeleteFlight request Initiated");
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                int res = repo.DeleteFlight(id);
                if (res == 1)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }




    }
}

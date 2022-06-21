using Cwiczenia7.Exceptions;
using Cwiczenia7.Models.DTO;
using Cwiczenia7.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cwiczenia7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public TripsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTripsAsync()//change name to Async later
        {
            var trips = await _dbService.GetTripsAsync();
            return Ok(trips);
        }

        [HttpPost]
        [Route("{idTrip}/clients")]
        public async Task<IActionResult> AssignToTripAsync(SomeSortOfClientTrip trip)
        {
            try
            {
                await _dbService.AssignToTripAsync(trip);
                return Ok("Client assigned to trip.");
            }
            catch (TripNotFoundException exc3)
            {
                return BadRequest(exc3.Message);
            }
            catch(ClientAssignedToTripException exc2)
            {
                return BadRequest(exc2.Message);    
            }
        }
    }
}

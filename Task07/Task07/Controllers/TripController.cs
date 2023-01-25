using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Task07.Models;
using Task07.Services;
using Task07.Models.DTO;

namespace Task07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {

        ITripDbService DbService;

        public TripController(ITripDbService db)
        {
            this.DbService = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            try
            {
                var trips = await DbService.GetTripsAsync();
                return Ok(trips);
            }
            catch (Exception e) 
            { return NotFound(e.Message); }
            
        }

        [HttpPost]
        public async Task<IActionResult> AddTripToClientAsync([FromRoute] int idTrip, [FromBody] AddTripToClientRequestDto dto)
        {
            try
            {
                await DbService.AddTripToClientAsync(idTrip, dto);
                return Ok("Client added to trip");
            }
            catch (Exception e)
            { return NotFound(e.Message); 
        }
        }

    }
}

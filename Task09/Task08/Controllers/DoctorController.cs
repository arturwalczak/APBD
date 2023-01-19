using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task08.Models.DTO;
using Task08.Services;

namespace Task08.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorDbService service;

        public DoctorController(IDoctorDbService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var result = await service.GetDoctorsAsync();

            if (result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorDto dto)
        {
            var result = await service.AddDoctorAsync(dto);

            if (result != "Added")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeDoctor([FromRoute] int id, [FromBody] DoctorDto dto)
        {
            var result = await service.ChangeDoctorAsync(id, dto);

            if (result != "Changed")
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] int id)
        {
            var result = await service.DeleteDoctorAsync(id);

            if (result != "Delete")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("prescription/{id}")]
        public async Task<IActionResult> GetPrescription([FromRoute] int id)
        {
            var result = await service.GetPrescriptionAsync(id);

            if (result == null)
                return NoContent();

            return Ok(result);
        }
    }
}

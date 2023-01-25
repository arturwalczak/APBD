using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Task07.Services;

namespace Task07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        IClientDbService DbService;

        public ClientController(IClientDbService db)
        {
            this.DbService = db;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClient([FromRoute] int idClient)
        {
            try
            {
                await DbService.DeleteClientAsync(idClient);
                return Ok("Client deleted");
            }
            catch (Exception e)
            { return NotFound(e.Message); }

        }
    }
}

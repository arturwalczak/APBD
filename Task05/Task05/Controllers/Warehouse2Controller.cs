using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Task05.Models;
using Task05.Services;

namespace Task05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Warehouse2Controller : ControllerBase
    {
        private readonly IDBService dBService;

        public Warehouse2Controller(IDBService db)
        {
            this.dBService = db;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToWarehouse([FromBody] ProductWarehouse productWarehouse)
        {
            int idProductWarehouse;
            try { idProductWarehouse = await dBService.AddProductToWarehouseAsync(productWarehouse); }
            catch (Exception e) { return NotFound(e.Message); }
            return Ok($"Added");
        }
    }
}


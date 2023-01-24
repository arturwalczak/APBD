using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task04.Models;
using Task04.Services;

namespace Task04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IDBService DBService;

        public AnimalController(IDBService DBService)
        {
            this.DBService = DBService;
        }

        [HttpGet]
        public IActionResult GetAnimals([FromQuery] string orderBy)
        {
            List<Animal> animals = new List<Animal>();
             //animals = DBService.GetAnimals(orderBy); 
            try { animals = DBService.GetAnimals(orderBy); }
            catch
            {
                return BadRequest("column name does not exist in database");
            }
            return Ok(animals);
        }

        [HttpDelete("{idAnimal}")]
        public IActionResult DeleteAnimal([FromRoute] int idAnimal)
        {
            try { DBService.DeleteAnimal(idAnimal); }
            catch
            {
                return BadRequest("Not deleted");
            }
            
            return Ok("deleted");
        }

        [HttpPost]
        public IActionResult CreateAnimal([FromBody] Animal animal)
        {
            try { DBService.CreateAnimal(animal); }
            catch
            {
                return BadRequest("Not created");
            }
            
            return Ok("created");
        }

        [HttpPut("{idAnimal}")]
        public IActionResult ChangeAnimal([FromRoute] int idAnimal, [FromBody] Animal animal)
        {
            try { DBService.ChangeAnimal(idAnimal, animal); }
            catch
            {
                return BadRequest("Not changed");
            }
           
            return Ok("changed");
        }
    }
}

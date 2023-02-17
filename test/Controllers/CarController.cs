using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly DataContext _context;
        public CarController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Car>))]
        public async Task<ActionResult<List<Car>>> GetCars()
        {
            return Ok(await _context.Cars.ToListAsync());
        }

        [HttpGet("{carId}")]
        public async Task<ActionResult<List<Car>>> GetCarById(int carId)
        {
            var car = await _context.Cars.FindAsync(carId);
            if (car == null) return BadRequest("Car Not found");

            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<List<Car>>> CreateCar([FromBody] Car carCreate)
        {
            _context.Cars.Add(carCreate);
            await _context.SaveChangesAsync();

            return Ok("Car Created");
        }

        [HttpPut]
        public async Task<ActionResult<List<Car>>> UpdateCare([FromBody] Car carUpdate)
        {
            var car = await _context.Cars.FindAsync(carUpdate.Id);
            if (car == null)
                return BadRequest("Car Not Found !");            

            car.Name = carUpdate.Name;
            car.HorsePower= carUpdate.HorsePower;
            car.Torque= carUpdate.Torque;

            await _context.SaveChangesAsync();
            return Ok(await _context.Cars.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Car>>> DeleteCare([FromBody] int carId)
        {
            var car = await _context.Cars.FindAsync(carId);
            if (car == null)
                return BadRequest("Car Not Found !");

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return Ok("Car Deleted !");
        }


    }
}

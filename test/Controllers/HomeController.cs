using Microsoft.AspNetCore.Mvc;
using test.Interfaces;
using test.Models;
using test.Repository;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Car>))]
        public IActionResult GetCars()
        {
            var cars = _carRepository.GetCars();

            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(cars);
        }

        [HttpGet("{carId}")]
        [ProducesResponseType(200, Type = typeof(Car))]
        [ProducesResponseType(400)]
        public IActionResult GetCarById(int carId)
        {
            if(!_carRepository.CarExists(carId)) 
                return NotFound();

            var car = _carRepository.GetCarById(carId);

            if(!ModelState.IsValid) return BadRequest(ModelState); 
            
            return Ok(car);
        }

    }
}

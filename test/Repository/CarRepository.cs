using test.Data;
using test.Interfaces;
using test.Models;

namespace test.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;
        public CarRepository(DataContext context) { 
            _context = context;
        }

        public ICollection<Car> GetCars()
        {
            return _context.Cars.OrderBy(p => p.Id).ToList();
        }

        public Car GetCarById(int id)
        {
            return _context.Cars.Where(p => p.Id == id).FirstOrDefault();
        }
        
        public bool CarExists(int carId)
        {
            return _context.Cars.Any(p => p.Id == carId);
        }

        public bool CreateCar(Car car)
        {
            _context.Cars.Add(car);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

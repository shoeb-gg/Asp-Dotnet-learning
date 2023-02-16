using test.Models;

namespace test.Interfaces
{
    public interface ICarRepository
    {
        ICollection<Car> GetCars();

        Car GetCarById(int id);
        bool CarExists(int carId);

    }
}

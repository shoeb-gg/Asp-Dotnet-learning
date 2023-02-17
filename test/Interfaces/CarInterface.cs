using test.Models;

namespace test.Interfaces
{
    public interface ICarRepository
    {
        ICollection<Car> GetCars();

        Car GetCarById(int id);
        bool CreateCar(Car car);
        bool CarExists(int carId);

        bool Save();

    }
}

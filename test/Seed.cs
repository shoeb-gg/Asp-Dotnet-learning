using test.Data;
using test.Models;


namespace test
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Cars.Any())
            {
                var cars  = new List<Car>()
                {
                    new Car()
                    {
                        Name = "Tesla Model S Plaid",
                        HorsePower = 1020,
                        Torque = 800
                    },
                    new Car()
                    {
                        Name = "Toyota Prius 2021",
                        HorsePower = 120,
                        Torque = 90
                    },
                    new Car()
                    {
                        Name = "Porsche 911 Turbo S",
                        HorsePower = 1020,
                        Torque = 800
                    }
                };
                dataContext.Cars.AddRange(cars);
                dataContext.SaveChanges();
            }
        }
    }
}
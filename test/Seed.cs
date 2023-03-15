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
            if (!dataContext.Products.Any())
            {
                var products = new List<Product>()
                {
                    new Product()
                    {
                        Name = "Iphone 14 Pro Max",
                        Brand = "Apple",
                        Description = "Overpriced Handcuff",
                        Price = 999,
                        ImageUrl = "https://adminapi.applegadgetsbd.com/storage/media/large/iPhone-14-Pro-Max-Space-Black-6723.jpg"
                    }
                };
                dataContext.Products.AddRange(products);
                dataContext.SaveChanges();
            }
        }
    }
}
using Microsoft.EntityFrameworkCore;
using test.Models;


namespace test.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

    }
}

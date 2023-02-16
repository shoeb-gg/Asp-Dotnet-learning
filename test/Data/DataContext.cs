using Microsoft.EntityFrameworkCore;
using test.Models;


namespace test.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Car>().HasKey(c =>  c.CarId );
        }
    }
}

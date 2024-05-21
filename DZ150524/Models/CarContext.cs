using Microsoft.EntityFrameworkCore;

namespace DZ150524.Models
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

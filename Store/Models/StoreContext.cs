using Microsoft.EntityFrameworkCore;

namespace Store.Models
{
    public class StoreContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ReviewsUser> Users { get; set; }
        public StoreContext(DbContextOptions options) : 
            base(options){}
    }
}
using CreativeStore.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CreativeStore.Data
{
    public class CreativeDbContext : DbContext
    {
        public CreativeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet <User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

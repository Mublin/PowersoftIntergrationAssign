using Microsoft.EntityFrameworkCore;
using ContosaPizza.Models;

namespace ContosaPizza.Data
{
    public class ContosoPizzaContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ContosaPizza;Trusted_Connection=True;Encrypt=False;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

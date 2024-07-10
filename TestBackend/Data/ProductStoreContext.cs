using Microsoft.EntityFrameworkCore;
using TestBackend.Models;
namespace TestBackend.Data;

public class ProductStoreContext(DbContextOptions<ProductStoreContext>  options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}

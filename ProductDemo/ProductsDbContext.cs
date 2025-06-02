using Microsoft.EntityFrameworkCore;
using ProductDemo.Domain.Models;

namespace ProductDemo
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
        }
    }
}

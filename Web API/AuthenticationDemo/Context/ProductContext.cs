using AuthenticationDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationDemo.Context
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}

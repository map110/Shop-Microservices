using Microsoft.EntityFrameworkCore;
using Products.Domain.Categories;
using Products.Domain.Products;

namespace Products.Infrastructure;

public class ProductDbContext:DbContext
{
    public ProductDbContext(DbContextOptions options):base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } 
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Category.CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new Product.ProductConfiguration());
    }
}
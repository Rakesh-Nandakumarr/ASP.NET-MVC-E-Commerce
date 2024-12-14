using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestApp.Models;

namespace TestApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Review> Reviews { get; set; }
    
    //override OnModelCreating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Seed Categories
        var categories = new List<Category>();
        for (int i = 1; i <= 7; i++)
        {
            categories.Add(new Category
            {
                Id = i, // Ensure IDs are explicitly provided for seeding
                Name = $"Category {i}",
                Description = $"Description for Category {i}",
                Slug = $"category-{i}",
                Status = true
            });
        }

        modelBuilder.Entity<Category>().HasData(categories);

        // Seed Products
        var products = new List<Product>();
        int productId = 1;
        foreach (var category in categories)
        {
            for (int i = 1; i <= 8; i++) // 5 Products per Category
            {
                products.Add(new Product
                {
                    Id = productId++,
                    Name = $"Product {category.Id}-{i}",
                    Description = $"Description for Product {category.Id}-{i}",
                    Price = 10.99m + i,
                    Brand = $"Brand {i}",
                    Stock = 100 + i,
                    Rating = (i % 5) + 1,
                    Slug = $"product-{category.Id}-{i}",
                    Status = true,
                    CategoryId = category.Id, // Link Product to Category
                    MetaTitle = $"Meta Title for Product {category.Id}-{i}",
                    MetaDescription = $"Meta Description for Product {category.Id}-{i}",
                    MetaKeywords = $"keyword-{category.Id}-{i}"
                });
            }
        }
        
        modelBuilder.Entity<Product>().HasData(products);
        
        // Seed images 5 per product only 1 main image use placeholder.it for different images 
        var images = new List<Image>();
        int imageId = 1;
        foreach (var product in products)
        {
            for (int i = 1; i <= 5; i++)
            {
                images.Add(new Image
                {
                    Id = imageId++,
                    Url = $"https://via.placeholder.com/150?text={product.Name}-{i}",
                    IsMain = i == 1,
                    ProductId = product.Id
                });
            }
        }
        
        modelBuilder.Entity<Image>().HasData(images);
        


        // define relationship between Product and Category
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        // define relationship between Review and Product
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.ProductId);

        // define relationship between Image and Product
        modelBuilder.Entity<Image>()
            .HasOne(i => i.Product)
            .WithMany(p => p.Images)
            .HasForeignKey(i => i.ProductId);
    }
}

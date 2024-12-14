using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Models;
using System.Threading.Tasks;

namespace TestApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
        
    }

    public async Task<IActionResult> Index(string? search)
    {
        // return View(await _context.Categories.Include(c => c.Products).ThenInclude(p => p.Images).ToListAsync());
        // pass only that category status is true and product status is true and stock is greater than 0 and if search is not null the product name contains search
        var categories = await _context.Categories
            .Include(c => c.Products)
            .ThenInclude(p => p.Images)
            .Where(c => c.Status == true)
            .Select(c => new Category
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Slug = c.Slug,
                Status = c.Status,
                Products = c.Products.Where(p => p.Status == true && p.Stock > 0 && (search == null || p.Name.Contains(search))).ToList()
            })
            .ToListAsync();
        
        //pass the search term to the view
        ViewBag.Search = search;
        
        return View(categories);
        
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

public async Task<string> Seed()
{
    try
    {
        // Ensure database is migrated to the latest version
        _context.Database.Migrate();

        const int CAT_COUNT = 10; // Number of categories to seed
        const int PRODUCT_COUNT_PER_CATEGORY = 5; // Products per category
        var createdProducts = new List<Product>();

        // Seed Categories if they do not exist
        if (!_context.Categories.Any())
        {
            var categories = new List<Category>();

            for (int i = 1; i <= CAT_COUNT; i++)
            {
                categories.Add(new Category
                {
                    Name = $"Category {i}",
                    Description = $"Description for Category {i}",
                    Slug = $"category-{i}",
                    Status = true,
                    Products = new List<Product>() // Initialize Products list
                });
            }

            await _context.Categories.AddRangeAsync(categories);
            await _context.SaveChangesAsync();
        }

        // Seed Products if they do not exist
        if (!_context.Products.Any())
        {
            var categories = _context.Categories.Include(c => c.Products).ToList();
            var products = new List<Product>();

            foreach (var category in categories)
            {
                for (int i = 1; i <= PRODUCT_COUNT_PER_CATEGORY; i++)
                {
                    var product = new Product
                    {
                        Name = $"Product {category.Id}-{i}",
                        Description = $"Description for Product {category.Id}-{i}",
                        Price = 10.99m + i,
                        Brand = $"Brand {i}",
                        Stock = 100 + i,
                        Rating = (i % 5) + 1,
                        Slug = $"product-{category.Id}-{i}",
                        Status = true,
                        CategoryId = category.Id,
                        MetaTitle = $"Meta Title for Product {category.Id}-{i}",
                        MetaDescription = $"Meta Description for Product {category.Id}-{i}",
                        MetaKeywords = $"keyword-{category.Id}-{i}",
                        Reviews = new List<Review>(), // Initialize Reviews list
                        Images = new List<Image>()   // Initialize Images list
                    };

                    products.Add(product);
                    createdProducts.Add(product);
                }
            }

            await _context.Products.AddRangeAsync(products);
            await _context.SaveChangesAsync();
        }

        // Include created products with their categories in the response
        var result = createdProducts
            .Select(p => new
            {
                ProductName = p.Name,
                CategoryName = _context.Categories.FirstOrDefault(c => c.Id == p.CategoryId)?.Name
            })
            .ToList();

        var resultString = string.Join("\n", result.Select(r => $"Product: {r.ProductName}, Category: {r.CategoryName}"));
        return $"Database seeded successfully!\n\nCreated Products:\n{resultString}";
    }
    catch (DbUpdateException dbEx)
    {
        return $"Database update error: {dbEx.Message}\n{dbEx.InnerException?.Message}\n{dbEx.StackTrace}";
    }
    catch (Exception ex)
    {
        return $"An error occurred during seeding: {ex.Message}\n{ex.StackTrace}";
    }
}




}

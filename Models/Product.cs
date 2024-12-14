namespace TestApp.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Brand { get; set; }
    public int Stock { get; set; }
    public int? Rating { get; set; }
    // many reviews for a product
    public List<Review>? Reviews { get; set; }
    // many images for a product
    public List<Image>? Images { get; set; }
    // belongs to a category
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
    
    public string? Slug { get; set; }
    public bool Status { get; set; } = false;
    
    // add nullable metafields
    public string? MetaTitle { get; set; }
    public string? MetaDescription { get; set; }
    public string? MetaKeywords { get; set; }
}
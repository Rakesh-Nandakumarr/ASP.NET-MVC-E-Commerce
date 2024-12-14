namespace TestApp.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<Product>? Products { get; set; }
    public string? Slug { get; set; }
    public bool Status { get; set; } = false;
    
}
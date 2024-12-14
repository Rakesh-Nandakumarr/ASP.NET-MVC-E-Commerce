namespace TestApp.Models;

public class Image
{
    public int Id { get; set; }
    public string Url { get; set; }
    public bool IsMain { get; set; } = false;
    public Product? Product { get; set; }
    public int ProductId { get; set; }
}
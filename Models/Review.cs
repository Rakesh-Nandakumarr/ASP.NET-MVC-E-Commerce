using Microsoft.AspNetCore.Identity;

namespace TestApp.Models;

public class Review
{
    public int Id { get; set; }
    public string Message { get; set; }
    public Product Product { get; set; }
    public int ProductId { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
    // created at
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
}
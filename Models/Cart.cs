using Microsoft.AspNetCore.Identity;

namespace TestApp.Models;

public class Cart
{
    public int Id { get; set; }
    public List<CartItem> CartItems { get; set; }
    public bool IsCheckedOut { get; set; }
    public DateTime? CheckedOutAt { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalTax { get; set; }
    public decimal ShippingFee { get; set; } = 100;
    public decimal Total { get; set; }
    
    //order location
    public string? Address { get; set; }
    public string? ContactNumber { get; set; }
    
    //shipping status
    public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.Pending;
    public IdentityUser? User { get; set; }
    public string UserId { get; set; }
}
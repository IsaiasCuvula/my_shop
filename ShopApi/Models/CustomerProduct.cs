namespace ShopApi.Models;

public class CustomerProduct
{
    public long CustomerId { get; set; }
    public required Customer Customer { get; set; }
    public long ProductId { get; set; }
    public required Product Product { get; set; }
    public int Quantity { get; set; } 
    public DateTime PurchaseDate { get; set; } 
    
}
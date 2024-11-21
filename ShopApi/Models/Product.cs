using System.Text.Json.Serialization;

namespace ShopApi.Models;

public class Product
{
    public long Id { get; set; }
    public required string Brand { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Quantity { get; set; }
    public int ProductNumber { get; set; }
    public required string Image { get; set; }
    
    [JsonIgnore]
    public ICollection<CustomerProduct> CustomerProducts { get; set; }
    
}
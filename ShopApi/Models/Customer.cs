using System.Text.Json.Serialization;

namespace ShopApi.Models;

public class Customer
{
    public long Id { get; set; } 
    public required string Name { get; set; } 
    public int IdCardNumber { get; set; } 
    public required string City { get; set; } 
    public required string Address { get; set; } 
    public required string Phone { get; set; } 
    public required string Email { get; set; } 
    public int CustomerNumber { get; set; }
    
    [JsonIgnore]
    public ICollection<CustomerProduct> CustomerProducts { get; set; }
}
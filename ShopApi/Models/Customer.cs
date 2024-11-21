using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShopApi.Models;

public class Customer
{
    public long Id { get; set; } 
    [MaxLength(100)]
    public required string Name { get; set; } 
    public long IdCardNumber { get; set; }
    [MaxLength(254)]
    public required string City { get; set; }
    [MaxLength(254)]
    public required string Address { get; set; } 
    [MaxLength(20)]
    public required string Phone { get; set; } 
    [MaxLength(254)]
    public required string Email { get; set; } 
    public long CustomerNumber { get; set; }
    
    [JsonIgnore]
    public ICollection<CustomerProduct> CustomerProducts { get; set; }
}
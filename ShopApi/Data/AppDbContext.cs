using Microsoft.EntityFrameworkCore;
using ShopApi.Models;

namespace ShopApi.Data;

public class AppDbContext: DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<CustomerProduct> CustomerProducts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    
}
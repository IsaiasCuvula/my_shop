using Microsoft.EntityFrameworkCore;
using ShopApi.Data;
using ShopApi.Utilities;

namespace ShopApi.Repositories.Product;
using Models; 

public class ProductRepository: IProductRepository
{
    private readonly AppDbContext _context;

    public  ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Product>> GetExpiredProductsAsync()
    {
        var today = DateTime.UtcNow.ToUniversalTime();
        
        var query = @"
                    SELECT * FROM Products p
                    WHERE p.expiration_date <= {0}";
        
        Console.WriteLine("**********************************");
        Console.WriteLine($"Today: {today}");
        Console.WriteLine("**********************************");

        return await _context.Products
            .FromSqlRaw(query, today)
            .ToListAsync();
    }

    public async Task<List<Product>> GetProductsExpiringInNext24HoursAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Product>> GetProductsWithLongShelfLifeAsync()
    {
        throw new NotImplementedException();
    }
    
    public async Task<Product?> GetByIdAsync(long id)
    {
        return await _context.Products.FirstOrDefaultAsync(c=> c.Id==id);
    }

    public async Task<Product?> GetByNumberAsync(long productNumber)
    {
        return await _context.Products
            .FirstOrDefaultAsync(p=> p.ProductNumber == productNumber);
    }

    public  async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }
    
    public  async Task<Product> AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async  Task<Product> UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async  Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}
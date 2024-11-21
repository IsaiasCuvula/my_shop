
namespace ShopApi.Repositories.Product;
using Models; 

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(long id);
    Task<List<Product>> GetAllAsync();
    Task<Product> AddAsync(Product customer);
    Task<Product> UpdateAsync(Product customer);
    Task DeleteAsync(Product customer);
}
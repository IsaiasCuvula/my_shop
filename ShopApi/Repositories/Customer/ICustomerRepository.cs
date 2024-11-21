using ShopApi.Models;

namespace ShopApi.Repositories;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(long id);
    Task<List<Customer>> GetAllAsync();
    Task AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(Customer customer);
}
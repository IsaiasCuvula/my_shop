using Microsoft.EntityFrameworkCore;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories;

public class CustomerRepository: ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Customer?> GetByIdAsync(long id)
    {
     return await _context.Customers.FirstOrDefaultAsync(c=> c.Id==id);
    }

    public  async Task<List<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public  async Task AddAsync(Customer customer)
    {
       await _context.Customers.AddAsync(customer);
       await _context.SaveChangesAsync();
    }

    public async  Task UpdateAsync(Customer customer)
    {
         _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    public async  Task DeleteAsync(Customer customer)
    {
         _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
}
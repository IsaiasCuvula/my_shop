using Microsoft.EntityFrameworkCore;
using ShopApi.Data;
using ShopApi.Models;
using ShopApi.Utilities;

namespace ShopApi.Repositories;

public class CustomerRepository: ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }
   

    public async Task<List<Customer>> GetAllCustomerShoppedLasWeekAsync()
    {
        var oneWeekAgo = AppHelpers.GetLastWeekMonday();
        
        return await _context.Orders
            .Where(o => o.OrderDate >= oneWeekAgo)
            .Select(o => o.Customer)
            .Distinct()
            .ToListAsync();
    }
    
    public async Task<Customer?> GetByNumberAsync(long customerNumber)
    {
        return await _context.Customers
            .FirstOrDefaultAsync(c=> c.CustomerNumber == customerNumber);
    }
    
    public async Task<Customer?> GetByIdAsync(long id)
    {
     return await _context.Customers.FirstOrDefaultAsync(c=> c.Id==id);
    }

    public  async Task<List<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public  async Task<Customer> AddAsync(Customer customer)
    {
       await _context.Customers.AddAsync(customer);
       await _context.SaveChangesAsync();
       return customer;
    }

    public async  Task<Customer> UpdateAsync(Customer customer)
    {
         _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async  Task DeleteAsync(Customer customer)
    {
         _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
}
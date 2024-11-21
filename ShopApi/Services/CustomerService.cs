using ShopApi.Models;
using ShopApi.Repositories;

namespace ShopApi.Services;

public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    //TODO - Task AddAsync(Customer customer);
    //TODO - Task UpdateAsync(Customer customer);
  
    public async Task<ApiResponse<Customer>>  DeleteCustomerById(long id)
    {
        ApiResponse<Customer> response = new ApiResponse<Customer>();
        try
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            
            if (customer == null)
            {
                response.Message = "Customer not found";
                return response;
            }
           
            await _customerRepository.DeleteAsync(customer);
           
            response.Data = null;
            response.Message = "Customer deleted successfully";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to get customer with id: {id} - {e}");
            return response;
        }
    }
    
    public async Task<ApiResponse<Customer>> GetCustomerById(long id)
    {
        ApiResponse<Customer> response = new ApiResponse<Customer>();
        try
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                response.Message = "Customer not found";
                return response;
            }
            response.Data = customer;
            response.Message = "Customer successfully retrieved";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to get customer with id: {id} - {e}");
            return response;
        }
    }

    public async Task<ApiResponse<List<Customer>>> GetAllCustomers()
    {
        ApiResponse<List<Customer>> response = new ApiResponse<List<Customer>>();
        try
        {
          var customers = await _customerRepository.GetAllAsync();
          response.Data = customers;
          response.Message = customers.Count == 0 ? "There is no customer created yet":"Customers successfully retrieved";
          return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to get all customers: {e}");
            return response;
        }
    }
}
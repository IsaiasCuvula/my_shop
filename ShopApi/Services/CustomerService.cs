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
            Console.WriteLine($"GetAllCustomers Error: {e}");
            return response;
        }
    }
}
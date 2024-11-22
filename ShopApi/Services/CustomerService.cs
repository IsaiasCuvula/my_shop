using ShopApi.Dtos;
using ShopApi.Mappers;
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

    
    public async Task<ApiResponse<List<Customer>>> GetAllCustomerShoppedLasWeek()
    {
        ApiResponse<List<Customer>> response = new ApiResponse<List<Customer>>();
        try
        {
            var customers = await _customerRepository.GetAllCustomerShoppedLasWeekAsync();
            response.Data = customers;
            response.Message = customers.Count == 0 ? "There is no customer who shopped last week yet":"Customers who shopped last week successfully retrieved";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to get all customers who shopped last week: {e}");
            return response;
        }
    }
    
    public async Task<ApiResponse<Customer>> UpdateCustomer(CustomerDto dto, long customerId)
    {
        ApiResponse<Customer> response = new ApiResponse<Customer>();
        try
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                response.Message = "Customer not found";
                return response;
            }
            
            customer.Name = dto.Name;
            customer.Email = dto.Email;
            customer.Phone = dto.Phone;
            customer.Address = dto.Address;
            customer.City = dto.City;
            customer.IdCardNumber = dto.IdCardNumber;
            
            
            var updatedCustomer = await _customerRepository.UpdateAsync(customer);
           
            response.Data = updatedCustomer;
            response.Message = "Customer updated successfully";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to updated customer with id: {customerId} - {e}");
            return response;
        }
    }
    
    public async Task<ApiResponse<Customer>>  CreateCustomer(CustomerDto dto)
    {
        ApiResponse<Customer> response = new ApiResponse<Customer>();
        try
        {
            Customer customer = CustomerMapper.MapToEntity(dto);
           
           var savedCustomer = await _customerRepository.AddAsync(customer);
           
            response.Data = savedCustomer;
            response.Message = "Customer created successfully";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to create customer - {e}");
            return response;
        }
    }
  
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
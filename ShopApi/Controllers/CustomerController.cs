using Microsoft.AspNetCore.Mvc;
using ShopApi.Models;
using ShopApi.Services;

namespace ShopApi.Controllers;

[Route("api/v1/customers")]
[ApiController]
public class CustomerController: ControllerBase
{
    
    private readonly CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<Customer>>> GetCustomerById(int id)
    {
        return Ok(await _customerService.GetCustomerById(id));
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<Customer>>>> GetAllCustomers()
    {
        var customers = await _customerService.GetAllCustomers();
        return Ok(customers);
    }
    
}
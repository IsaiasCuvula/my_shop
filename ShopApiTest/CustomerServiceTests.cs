using FakeItEasy;
using ShopApi.Models;
using ShopApi.Repositories;

namespace ShopApiTest;

public class CustomerServiceTests
{
    private readonly ICustomerRepository _customerRepository; 

    public CustomerServiceTests()
    {
        _customerRepository = A.Fake<ICustomerRepository>();
    }

     [Fact]
     public async Task GetUserByIdAsync_ShouldReturnUser()
     {
         //Arrange
         const int customerId = 1;
         var customer = new Customer
         {
             Id = customerId,
             Name = "John Doe",
             IdCardNumber = 123456789,
             City = "New York",
             Address = "123 Elm Street",
             Phone = "+1-555-1234",
             Email = "johndoe@example.com",
             CustomerNumber = 987654321,
         };
        
         A.CallTo(() => _customerRepository.GetByIdAsync(customerId))
             .Returns(Task.FromResult<Customer?>(customer));
        
         //Act
         var result = await _customerRepository.GetByIdAsync(customerId);
        
         //Assert
         Assert.Equal(customer, result);
    }
    
    [Fact]
    public async Task GetCustomers_Returns_Correct_Number_Of_Customers()
    {
        //Arrange
        int numberOfCustomers = 5;
        var fakeCustomers = A.CollectionOfDummy<Customer>(numberOfCustomers)
            .ToList();

        A.CallTo(() =>  _customerRepository.GetAllAsync())
            .Returns(Task.FromResult(fakeCustomers));

        //Act
        var result = await  _customerRepository.GetAllAsync();

        //Assert
        Assert.Equal(numberOfCustomers, result.Count());
    }
}
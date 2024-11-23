using ShopApi.Dtos;
using ShopApi.Models;
using ShopApi.Utilities;

namespace ShopApi.Mappers;

public class CustomerMapper
{
    public Customer MapToEntity(CustomerDto dto)
    {
        return new Customer
        {
            Name = dto.Name,
            IdCardNumber = dto.IdCardNumber,
            City = dto.City,
            Address = dto.Address,
            Phone = dto.Phone,
            Email = dto.Email,
            CustomerNumber = AppHelpers.GenerateRandomNumber()
        };
    }
}
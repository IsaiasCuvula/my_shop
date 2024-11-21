using ShopApi.Dtos;
using ShopApi.Models;

namespace ShopApi.Mappers;

public class OrderMapper
{
    public static Order MapToEntity(OrderDto dto)
    {
        return new Order
        {
            CustomerNumber = dto.CustomerNumber,
            ProductsNumbers = dto.ProductsNumbers,
            OrderDate = dto.OrderDate.ToUniversalTime(),
            Quantity = dto.Quantity,
            PaymentDate = dto.PaymentDate.ToUniversalTime(),
            PaymentStatus = dto.PaymentStatus,
            ReturnStatus = dto.ReturnStatus
        };
    }
}
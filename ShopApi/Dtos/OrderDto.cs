using ShopApi.Utilities;

namespace ShopApi.Dtos;

public record OrderDto(
        long CustomerNumber,
        List<long> ProductsNumbers,
        int Quantity,
        DateTime OrderDate,
        DateTime PaymentDate,
        PaymentStatus PaymentStatus,
        ReturnStatus ReturnStatus
);
using ShopApi.Utilities;

namespace ShopApi.Dtos;

public record OrderDto(
        long CustomerNumber,
        long ProductNumber,
        DateTime OrderDate,
        DateTime PaymentDate,
        PaymentStatus PaymentStatus,
        ReturnStatus ReturnStatus
);
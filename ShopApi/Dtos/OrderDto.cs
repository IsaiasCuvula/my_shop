using ShopApi.Utilities;

namespace ShopApi.Dtos;

public record OrderDto(
        long CustomerNumber,
        long ProductNumber,
        int Quantity,
        DateTime PaymentDate,
        PaymentStatus PaymentStatus,
        ReturnStatus ReturnStatus
);
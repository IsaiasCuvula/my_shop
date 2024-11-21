using ShopApi.Dtos;
using ShopApi.Mappers;
using ShopApi.Models;
using ShopApi.Repositories.Orders;
using ShopApi.Repositories.Product;

namespace ShopApi.Services;

public class OrderService
{
     private readonly IOrderRepository _orderRepository;
     private readonly IProductRepository _productRepository;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }
    
    public async Task<ApiResponse<List<Order>>>  CreateOrder(UserOrdersDto userOrdersDto)
    {
        ApiResponse<List<Order>> response = new ApiResponse<List<Order>>();
        List<Order> orders = new List<Order>();
        try
        {
            foreach (var dto in userOrdersDto.Orders)
            {
                Order order = OrderMapper.MapToEntity(dto);
                order.Total = await GetTotalByProduct(dto);
                var savedOrder = await _orderRepository.AddAsync(order);
                orders.Add(savedOrder);
            }
            
            //Payment 
            //decimal totalToPay = orders.Sum(o => o.Total) + userOrdersDto.DeliveryPrice;
            //Order number (orderId) save it into stripe
                
            response.Data = orders;
            response.Message = "Order created successfully";
            return response;
        }
        catch (Exception e)
        {
            response.Data = orders;
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to create order - {e}");
            return response;
        }
    }
    
    private async Task<decimal> GetTotalByProduct(OrderDto dto)
    {
        var product = await _productRepository.GetByNumberAsync(dto.ProductNumber);
        if (product == null){return 0;}
        return product.Price * dto.Quantity;
    }
    
    public async Task<ApiResponse<Order>> UpdateOrder(OrderDto dto, long orderId)
    {
        ApiResponse<Order> response = new ApiResponse<Order>();
        try
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                response.Message = "Order not found";
                return response;
            }
            Console.WriteLine("*******************************************");
            Console.WriteLine($"Old Total {order.Total}");
            Console.WriteLine($"New Total {await GetTotalByProduct(dto)}");
            Console.WriteLine("*******************************************");
            order.Total = await GetTotalByProduct(dto);
            order.Quantity = dto.Quantity;
            order.CustomerNumber = dto.CustomerNumber;
            order.ProductNumber = dto.ProductNumber;
            order.PaymentDate = dto.PaymentDate;
            order.PaymentStatus = dto.PaymentStatus;
            order.ReturnStatus = dto.ReturnStatus;
          
        
            var updatedOrder = await _orderRepository.UpdateAsync(order);
           
            response.Data = updatedOrder;
            response.Message = "Order updated successfully";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to updated order with id: {orderId} - {e}");
            return response;
        }
    }
  
    public async Task<ApiResponse<Order>>  DeleteOrderById(long id)
    {
        ApiResponse<Order> response = new ApiResponse<Order>();
        try
        {
            var order = await _orderRepository.GetByIdAsync(id);
            
            if (order == null)
            {
                response.Message = "Order not found";
                return response;
            }
           
            await _orderRepository.DeleteAsync(order);
           
            response.Data = null;
            response.Message = "Order deleted successfully";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to get order with id: {id} - {e}");
            return response;
        }
    }
    
    public async Task<ApiResponse<Order>> GetOrderById(long id)
    {
        ApiResponse<Order> response = new ApiResponse<Order>();
        try
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                response.Message = "Order not found";
                return response;
            }
            response.Data = order;
            response.Message = "Order successfully retrieved";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to get order with id: {id} - {e}");
            return response;
        }
    }

    public async Task<ApiResponse<List<Order>>> GetAllOrders()
    {
        ApiResponse<List<Order>> response = new ApiResponse<List<Order>>();
        try
        {
          var orders = await _orderRepository.GetAllAsync();
          response.Data = orders;
          response.Message = orders.Count == 0 ? "There is no order created yet":"Orders successfully retrieved";
          return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to get all orders: {e}");
            return response;
        }
    }


   
}
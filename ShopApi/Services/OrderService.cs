using ShopApi.Dtos;
using ShopApi.Mappers;
using ShopApi.Models;
using ShopApi.Repositories.Orders;

namespace ShopApi.Services;

public class OrderService
{
     private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
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
            
            order.CustomerNumber = dto.CustomerNumber;
            order.OrderDate = dto.OrderDate;
            order.ProductsNumbers = dto.ProductsNumbers;
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
    
    public async Task<ApiResponse<Order>>  CreateOrder(OrderDto dto)
    {
        ApiResponse<Order> response = new ApiResponse<Order>();
        try
        {
            Order order = OrderMapper.MapToEntity(dto);
           var savedOrder = await _orderRepository.AddAsync(order);
           
            response.Data = savedOrder;
            response.Message = "Order created successfully";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to create order - {e}");
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
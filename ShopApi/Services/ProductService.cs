using ShopApi.Dtos;
using ShopApi.Mappers;
using ShopApi.Models;
using ShopApi.Repositories.Product;

namespace ShopApi.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ApiResponse<List<Product>>> GetExpiredProducts()
    {
        ApiResponse<List<Product>> response = new ApiResponse<List<Product>>();
        try
        {
            var products = await _productRepository.GetExpiredProductsAsync();
            response.Data = products;
            response.Message = products.Count == 0 ? "There is no expired product yet":"All Expired products successfully retrieved";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to get all expired products: {e}");
            return response;
        }
    }
    
    public async Task<ApiResponse<Product>> UpdateProduct(ProductDto dto, long productId)
    {
        ApiResponse<Product> response = new ApiResponse<Product>();
        try
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                response.Message = "Product not found";
                return response;
            }
            
            product.Brand = dto.Brand;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Image = dto.Image;
            product.Quantity = dto.Quantity;
            product.ExpirationDate = dto.ExpirationDate;
            
            var updatedProduct = await _productRepository.UpdateAsync(product);
           
            response.Data = updatedProduct;
            response.Message = "Product updated successfully";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to updated product with id: {productId} - {e}");
            return response;
        }
    }
    
    public async Task<ApiResponse<Product>>  CreateProduct(ProductDto dto)
    {
        ApiResponse<Product> response = new ApiResponse<Product>();
        try
        {
           Product product = ProductMapper.MapToEntity(dto);
           var savedProduct = await _productRepository.AddAsync(product);
           
            response.Data = savedProduct;
            response.Message = "Product created successfully";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to create product - {e}");
            return response;
        }
    }
  
    public async Task<ApiResponse<Product>>  DeleteProductById(long id)
    {
        ApiResponse<Product> response = new ApiResponse<Product>();
        try
        {
            var product = await _productRepository.GetByIdAsync(id);
            
            if (product == null)
            {
                response.Message = "Product not found";
                return response;
            }
           
            await _productRepository.DeleteAsync(product);
           
            response.Data = null;
            response.Message = "Product deleted successfully";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to get product with id: {id} - {e}");
            return response;
        }
    }
    
    public async Task<ApiResponse<Product>> GetProductById(long id)
    {
        ApiResponse<Product> response = new ApiResponse<Product>();
        try
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                response.Message = "Product not found";
                return response;
            }
            response.Data = product;
            response.Message = "Product successfully retrieved";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to get product with id: {id} - {e}");
            return response;
        }
    }

    public async Task<ApiResponse<List<Product>>> GetAllProducts()
    {
        ApiResponse<List<Product>> response = new ApiResponse<List<Product>>();
        try
        {
          var products = await _productRepository.GetAllAsync();
          response.Data = products;
          response.Message = products.Count == 0 ? "There is no product created yet":"Products successfully retrieved";
          return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            Console.WriteLine($"Failed to get all products: {e}");
            return response;
        }
    }
}
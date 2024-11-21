using Microsoft.AspNetCore.Mvc;
using ShopApi.Dtos;
using ShopApi.Models;
using ShopApi.Services;

namespace ShopApi.Controllers;

[Route("api/v1/products")]
[ApiController]
public class ProductController: ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<Product>>> UpdateProduct(long id, ProductDto dto)
    {
        return Ok(await _productService.UpdateProduct(dto, id));
    }
    
    [HttpPost]
    public async Task<ActionResult<ApiResponse<Product>>> CreateProduct(ProductDto dto)
    {
        return Ok(await _productService.CreateProduct(dto));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<Product>>> GetProductById(long id)
    {
        return Ok(await _productService.GetProductById(id));
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<Product>>>> GetAllProducts()
    {
        var products = await _productService.GetAllProducts();
        return Ok(products);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<Product>>> DeleteProductById(long id)
    {
        return Ok(await _productService.DeleteProductById(id));
    }
}
using Microsoft.AspNetCore.Mvc;
using Products.Application.Features.Products;
using Products.Application.Features.Products.Create;
using Products.Application.Features.Products.Update;
using WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : CustomBaseController
{
    private readonly IProductService _productService;

    // Constructor üzerinden DI
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _productService.GetAllListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return CreateActionResult(await _productService.GetProductByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest request)
    {
        return CreateActionResult(await _productService.CreateProductAsync(request));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProductRequest request)
    {
        return CreateActionResult(await _productService.UpdateProductAsync(id, request));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return CreateActionResult(await _productService.DeleteProductAsync(id));
    }
}

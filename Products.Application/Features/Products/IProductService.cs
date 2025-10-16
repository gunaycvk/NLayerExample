using Products.Application.Features.Products.Create;
using Products.Application.Features.Products.DTO;
using Products.Application.Features.Products.Update;
using Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Features.Products
{
    public interface IProductService
    {
        Task<ServiceResult<List<ProductDto>>> GetTopPriceProductsAsync(int count);
        Task<ServiceResult<ProductDto>> GetProductByIdAsync(int id);
        Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request);
        Task<ServiceResult> UpdateProductAsync(int Id, UpdateProductRequest request);
        Task<ServiceResult> DeleteProductAsync(int Id);
        Task<ServiceResult<List<ProductDto>>> GetAllListAsync();
    }
}

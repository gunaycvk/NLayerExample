using Products.Application.Contracts.Persistence;
using Products.Application.Features.Products.Create;
using Products.Application.Features.Products.DTO;
using Products.Application.Features.Products.Update;
using Products.Domain.Entities;
using System.Net;


namespace Products.Application.Features.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepositry _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepositry productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<ServiceResult<ProductDto>> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                ServiceResult<ProductDto>.Fail(errorMessage: "product not found", HttpStatusCode.NotFound);

            }
            var productAsDto = new ProductDto(product!.Id, product.Name, product.Price, product.Stock);

            return ServiceResult<ProductDto>.Success(productAsDto!);
        }

        public async Task<ServiceResult<List<ProductDto>>> GetTopPriceProductsAsync(int count)
        {
            var products = await _productRepository.GetTopPriceProductsAsync(count);

            var productsAsDto = products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock)
           ).ToList();

            return new ServiceResult<List<ProductDto>>
            {
                Data = productsAsDto
            };
        }

        public Task<ServiceResult<List<ProductDto>>> GetAllListAsync()
        {
     
            var products = _productRepository.GetAll();

            var productsAsDto = products
                .Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock))
                .ToList();

            return Task.FromResult(ServiceResult<List<ProductDto>>.Success(productsAsDto));
        }


        public async Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request)
        {
            var product = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
            };

            await _productRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return ServiceResult<CreateProductResponse>.Success(new CreateProductResponse(product.Id));
        }


        public async Task<ServiceResult> UpdateProductAsync(int Id, UpdateProductRequest request)
        {
            var product = await _productRepository.GetByIdAsync(Id);

            if (product == null)
            {
                return ServiceResult.Fail("product is not found", HttpStatusCode.NotFound);
            }

            product.Name = request.Name;
            product.Price = request.Price;
            product.Stock = request.Stock;

            _productRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> DeleteProductAsync(int Id)
        {
            var product = await _productRepository.GetByIdAsync(Id);
            if (product == null)
            {
                return ServiceResult.Fail("product not found", HttpStatusCode.NotFound);

              
            }

            _productRepository.Delete(product);
            await _unitOfWork.SaveChangesAsync();
            return ServiceResult.Success();
        }
    }
}

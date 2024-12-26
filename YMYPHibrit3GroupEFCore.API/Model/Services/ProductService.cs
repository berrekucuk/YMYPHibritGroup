using System.Net;
using YMYPHibrit3GroupEFCore.API.Model.Repositories;
using YMYPHibrit3GroupEFCore.API.Model.Repositories.Entities;
using YMYPHibrit3GroupEFCore.API.Model.Services.Dtos;

namespace YMYPHibrit3GroupEFCore.API.Model.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<ServiceResult<List<ProductDto>>> GetAllList()
        {
            var products = await productRepository.GetAsync();

            var productsAsDto = new List<ProductDto>();
            products.ForEach(p =>
            {
                productsAsDto.Add(new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price * 1.2m,
                    CategoryName = p.CategoryName
                });
            });

            return ServiceResult<List<ProductDto>>.Success(productsAsDto);
        }


        public async Task<ServiceResult<ProductDto>> Get(int id)
        {
            var product = await productRepository.GetAsync(id);

            if (product == null)
            {
                return ServiceResult<ProductDto>.Failure("Product not found", System.Net.HttpStatusCode.NotFound);

            }

            var productAsDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price * 1.2m,
                CategoryName = product.CategoryName
            };

            return ServiceResult<ProductDto>.Success(productAsDto);
        }


        public async Task<ServiceResult<AddProductResponse>> AddAsync(AddProductRequest request)
        {
            var product = new Product()
            {
                Name = request.name,
                Price = request.Price,
                CategoryName = request.CategoryName,
                Barcode = Guid.NewGuid().ToString(),
                Stock = request.Stock
            };

            var newProduct = await productRepository.AddAsync(product);

            var response = new AddProductResponse(newProduct.Id);

            return ServiceResult<AddProductResponse>.Success(response, HttpStatusCode.Created);
        }

    }
}

using System.Net;
using YMYPHibritGroup.API.Model.Repositories;
using YMYPHibritGroup.API.Model.Repositories.Entities;
using YMYPHibritGroup.API.Model.Services.DTO;

namespace YMYPHibritGroup.API.Model.Services
{
    public class ProductService
    {
        private ProductRepository productRepository;

        private const decimal TaxRate = 1.20m;

        public ProductService()
        {
            productRepository = new ProductRepository();
        }

        public ServiceResult<List<ProductDto>> GetProducts()
        {
            var products = productRepository.GetProducts();

            var productsWithTax = new List<ProductDto>();

            foreach (var product in products)
            {
                var productDto = new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = CalculateTax(product.Price,TaxRate),
                    Stock = product.Stock,
                };

                productsWithTax.Add(productDto);
            }
            return ServiceResult<List<ProductDto>>.Success(productsWithTax,HttpStatusCode.OK);

        }

        public ServiceResult<ProductDto> GetProductById(int productId)
        {
            var product = productRepository.GetProduct(productId);

            if(product is null)
            {
                return ServiceResult<ProductDto>.Failure("Ürün bulunamadı", HttpStatusCode.NotFound);
            }

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = CalculateTax(product.Price,TaxRate),
                Stock = product.Stock,
            };

            return ServiceResult<ProductDto>.Success(productDto,HttpStatusCode.OK);
        }


        public ServiceResult<ProductDto> AddProduct(AddProductRequest addProductDto)
        {

            //Validator with Thirty Party(Database, API request)


            // Success => void
            // Success => return object   
            // Error => errors

            //ServiceResult : Burada dönüş tipi(hem hata hem olumlu) için bu sınfı yaptık.

            var hasProduct = productRepository.Any(p => p.Name == addProductDto.Name);

            if (hasProduct)
            {

                return ServiceResult<ProductDto>.Failure("Kaydetmeye çalıştığınız ürün ismi veritabanında bulunmaktadır.");
               
            }


            var product = new Product
            {
                Id = GenerateId(),
                Name = addProductDto.Name,
                Price = addProductDto.Price,
                Stock = addProductDto.Stock,
                Barcode = GenerateBarcode()
            };
            
            product = productRepository.AddProduct(product);

            var newProductDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = CalculateTax(product.Price, TaxRate),
                Stock = product.Stock,
            };

            return ServiceResult<ProductDto>.Success(newProductDto, HttpStatusCode.Created);
            
        }

        public ServiceResult UpdateProduct(UpdateProductRequest updateProductDto)
        {
            var anyProduct = productRepository.GetProduct(updateProductDto.Id);

            if(anyProduct is null)
            {
                return ServiceResult.Failure("Güncellenecek ürün bulunmadı",HttpStatusCode.NotFound);
            }

            anyProduct.Name = updateProductDto.Name;
            anyProduct.Price = updateProductDto.Price;

            productRepository.UpdateProduct(anyProduct);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public ServiceResult DeleteProduct(int productId)
        {
            var anyProduct = productRepository.GetProduct(productId);

            if (anyProduct is null)
            {
                return ServiceResult.Failure("Silinecek ürün bulunamadı", HttpStatusCode.NotFound);
            }

            productRepository.DeleteProduct(productId);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }


        private static decimal CalculateTax(decimal price, decimal taxRate)
        {
            return price * taxRate;
        }

        private int GenerateId()
        {
            var count = productRepository.GetProductCount();

            return count + 1;
        }

        private string GenerateBarcode()
        {
            return Guid.NewGuid().ToString();
        }
    }
}

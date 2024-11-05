using System.Net;
using YMYPHibritGroup.API.Model.Repositories;
using YMYPHibritGroup.API.Model.Repositories.Entities;
using YMYPHibritGroup.API.Model.Services.DTO;

namespace YMYPHibritGroup.API.Model.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        

        private const decimal TaxRate = 1.20m;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ServiceResult<List<ProductDto>> GetAll()
        {
            var products = _productRepository.GetAll();

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

        public ServiceResult<ProductDto> GetById(int productId)
        {
            var product = _productRepository.Get(productId);

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


        public ServiceResult<ProductDto> Add(AddProductRequest addProductDto)
        {

            //Validator with Thirty Party(Database, API request)


            // Success => void
            // Success => return object   
            // Error => errors

            //ServiceResult : Burada dönüş tipi(hem hata hem olumlu) için bu sınfı yaptık.

            var hasProduct = _productRepository.Any(p => p.Name == addProductDto.Name);

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
            
            product = _productRepository.Add(product);

            var newProductDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = CalculateTax(product.Price, TaxRate),
                Stock = product.Stock,
            };

            return ServiceResult<ProductDto>.Success(newProductDto, HttpStatusCode.Created);
            
        }

        public ServiceResult Update(UpdateProductRequest updateProductDto)
        {
            var anyProduct = _productRepository.Get(updateProductDto.Id);

            if(anyProduct is null)
            {
                return ServiceResult.Failure("Güncellenecek ürün bulunmadı",HttpStatusCode.NotFound);
            }

            anyProduct.Name = updateProductDto.Name;
            anyProduct.Price = updateProductDto.Price;

            _productRepository.Update(anyProduct);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public ServiceResult UpdateStock(int productId, int stock)
        {
            var anyProduct = _productRepository.Get(productId);

            if(anyProduct is null)
            {
                return ServiceResult.Failure("Stok güncellenecek ürün bulunamadı", HttpStatusCode.NotFound);
            }

            _productRepository.UpdateStock(productId, stock);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public ServiceResult UpdatePrice(int productId, decimal price)
        {
            var anyProduct = _productRepository.Get(productId);

            if(anyProduct is null)
            {
                return ServiceResult.Failure("Fiyat güncellenecek ürün bulunamadı", HttpStatusCode.NotFound);
            }

            _productRepository.UpdatePrice(productId, price);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }



        public ServiceResult Delete(int productId)
        {
            var anyProduct = _productRepository.Get(productId);

            if (anyProduct is null)
            {
                return ServiceResult.Failure("Silinecek ürün bulunamadı", HttpStatusCode.NotFound);
            }

            _productRepository.Delete(productId);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }


        private static decimal CalculateTax(decimal price, decimal taxRate)
        {
            return price * taxRate;
        }

        private int GenerateId()
        {
            var count = _productRepository.GetCount();

            return count + 1;
        }

        private string GenerateBarcode()
        {
            return Guid.NewGuid().ToString();
        }
    }
}

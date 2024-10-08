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

        public List<ProductDto> GetProducts()
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
            return productsWithTax;

        }

        public ProductDto GetProductById(int productId)
        {
            var product = productRepository.GetProduct(productId);

            if(product is null)
            {
                throw new Exception("Product not found");
            }

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = CalculateTax(product.Price,TaxRate),
                Stock = product.Stock,
            };
        }


        public ProductDto AddProduct(AddProductDto addProductDto)
        {
            var product = new Product
            {
                Id = GenerateId(),
                Name = addProductDto.Name,
                Price = addProductDto.Price,
                Stock = addProductDto.Stock,
                Barcode = GenerateBarcode()
            };
            
            product = productRepository.AddProduct(product);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = CalculateTax(product.Price, TaxRate),
                Stock = product.Stock,
            };
        }

        public void UpdateProduct(UpdateProductDto updateProductDto)
        {
            var anyProduct = productRepository.GetProduct(updateProductDto.Id);

            if(anyProduct is null)
            {
                throw new Exception("Product not found");
            }

            anyProduct.Name = updateProductDto.Name;
            anyProduct.Price = updateProductDto.Price;

            productRepository.UpdateProduct(anyProduct);
        }

        public void DeleteProduct(int productId)
        {
            var anyProduct = productRepository.GetProduct(productId);

            if (anyProduct is null)
            {
                throw new Exception("Product not found");
            }

            productRepository.DeleteProduct(productId);
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

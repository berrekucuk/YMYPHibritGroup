using System.Xml.Serialization;
using YMYPHibritGroup.API.Model.Repositories.Entities;

namespace YMYPHibritGroup.API.Model.Repositories
{
    public class ProductRepository : IProductRepository
    {
        //Static kullanmamızım amacı program çalıştığınızda ilk nesne örneğini oluşturur ve memory de sürekli oluşmamış olur.Bir kere newlemek yeterli olucaktır.
        private static List<Product> Products { get; set; }

        static ProductRepository()
        {
            Products = 
            [
                new Product {Id=1, Name = "Product 1", Price = 100, Stock = 10 },
                new Product {Id=2, Name = "Product 2", Price = 200, Stock = 20 },
                new Product {Id=3, Name = "Product 3", Price = 300, Stock = 30 },
                new Product {Id=4, Name = "Product 4", Price = 400, Stock = 40 },
                new Product {Id=5, Name = "Product 5", Price = 500, Stock = 50 },
            ];
        }

        //public List<Product> GetProducts()
        //{
        //    return Products;
        //}

        public List<Product> GetAll() => Products;

        public bool Any(Func<Product, bool> fun)
        {
            return Products.Any(fun);
        } 

        public Product? Get(int id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }

        public Product Add(Product product)
        {
            Products.Add(product);
            return product;
        }

        public Product Update(Product product)
        {
            var existingProduct = Products.FirstOrDefault(p => p.Id == product.Id);
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;

            return existingProduct;
        }

        public void UpdatePrice(int id, decimal price)
        {
            var product = Products.Single(p => p.Id == id);
            product.Price = price;
        }

        public void UpdateStock(int id, int stock)
        {
            var product = Products.Single(x => x.Id == id);
            product.Stock = stock;
        }

        public int GetCount() =>  Products.Count();
        
   
        public void Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id ==id);
            Products.Remove(product);
        }

       


    }
}

using YMYPHibritGroup.API.Model.Repositories.Entities;

namespace YMYPHibritGroup.API.Model.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        bool Any(Func<Product, bool> fun);
        Product? GetProduct(int id);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);

        void DeleteProduct(int id);
        int GetProductCount();
    }
}

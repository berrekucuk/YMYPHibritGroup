using YMYPHibritGroup.API.Model.Repositories.Entities;

namespace YMYPHibritGroup.API.Model.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        bool Any(Func<Product, bool> fun);
        Product? Get(int id);
        Product Add(Product product);
        Product Update(Product product);
        void UpdatePrice(int id, decimal price);
        void UpdateStock(int id, int stock);

        void Delete(int id);
        int GetCount();
    }
}

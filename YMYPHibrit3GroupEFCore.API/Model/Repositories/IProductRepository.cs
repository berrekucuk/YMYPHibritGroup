using YMYPHibrit3GroupEFCore.API.Model.Repositories.Entities;

namespace YMYPHibrit3GroupEFCore.API.Model.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAsync();
        Task<Product> GetAsync(int id);
        Task<Product> AddAsync(Product product);
        Task UpdateAsyncGood(Product product);
        Task UpdateAsyncBad(Product product);
        Task DeleteAsync(int id);
    }
}

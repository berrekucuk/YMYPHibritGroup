using Microsoft.EntityFrameworkCore;
using YMYPHibrit3GroupEFCore.API.Model.Repositories.Entities;

namespace YMYPHibrit3GroupEFCore.API.Model.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        public async Task<List<Product>> GetAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await context.Products.FindAsync(id);

        }

        public async Task<Product> AddAsync(Product product)
        {
            var entity = await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return product;
        }
    }
}

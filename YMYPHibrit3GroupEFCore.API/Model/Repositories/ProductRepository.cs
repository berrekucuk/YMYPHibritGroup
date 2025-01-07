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
            // Change Tracker sisteminin durum takibini bize gösterir.
            var state1 = context.Entry(product).State;

            var entity = await context.Products.AddAsync(product);

            var state2 = context.Entry(product).State;

            await context.SaveChangesAsync();
            return product;
        }

        public async Task UpdateAsyncGood(Product product)
        {
            var state1 = context.Entry(product).State;

            context.Products.Update(product);

            var state2 = context.Entry(product).State;

            context.Entry(product).Property(x => x.Barcode).IsModified = false;

            await context.SaveChangesAsync();
        }

        //İlk kullandığımız yöntem yukarıdaki yöntem daha iyi yazılmış bir kod.
        public async Task UpdateAsyncBad(Product product)
        {
            var productToUpdate = await context.Products.FindAsync(product.Id);

            var state1 = context.Entry(productToUpdate).State;

            productToUpdate.Stock = product.Stock;
            productToUpdate.Price = product.Price;
            productToUpdate.Name = product.Name;

            var state2 = context.Entry(productToUpdate).State;

            //context.Products.Update(productToUpdate);


            await context.SaveChangesAsync();
        }

        public async Task UpdateAsBulkAsync(Product product)
        {
            await context.Products.Where(x => x.Id == product.Id).ExecuteUpdateAsync(update => update.SetProperty(x => x.Price, product.Price).SetProperty(x => x.Name,product.Name).SetProperty(x => x.Stock,product.Stock));
        }

        public async Task DeleteAsync(int id)
        {
            
            var productToDelete = context.Products.Find(id);
            
            context.Products.Remove(productToDelete!);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsBulkAsync(int id)
        {
            //delete product where id = 2;

            await context.Products.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
    }
}

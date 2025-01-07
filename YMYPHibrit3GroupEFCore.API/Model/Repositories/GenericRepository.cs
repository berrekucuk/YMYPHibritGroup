using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YMYPHibrit3GroupEFCore.API.Model.Repositories.Entities;

namespace YMYPHibrit3GroupEFCore.API.Model.Repositories
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class
    {
        public readonly DbSet<T> DbSet = context.Set<T>();

        //productRepository.Where(x => x.Name == "test").OrderBy(x => x.price).Tolist();
        //Where : Verilen koşula (predicate) göre DbSet'teki verileri filtreler ve IQueryable olarak döner.
        public IQueryable<T> Where(Func<T, bool> predicate)
        {
            //AsQueryable: Bir koleksiyonu IQueryable türüne dönüştürür. Bu, sorgunun daha sonra veritabanına gönderilmek üzere yapılandırılmasına olanak tanır ve veritabanı tarafında işlenmesini sağlar.
            return DbSet.Where(predicate).AsQueryable();
        }

        //Any: Verilen koşula (predicate) uygun bir kayıt olup olmadığını kontrol eder ve sonucu bool olarak döner.
        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            //AnyAsync: Asenkron olarak çalışır ve belirli bir koşula uyan herhangi bir kaydın olup olmadığını kontrol eder. bool türünde bir sonuç döner ve genellikle veritabanında performanslı sorgular oluşturur.
            return await DbSet.AnyAsync(predicate);
        }

        public async Task<List<T>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await DbSet.FindAsync(id);

            DbSet.Remove(entity);
        }


    }
}

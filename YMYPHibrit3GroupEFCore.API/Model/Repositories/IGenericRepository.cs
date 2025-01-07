using System.Linq.Expressions;

namespace YMYPHibrit3GroupEFCore.API.Model.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<bool> Any(Expression<Func<T, bool>> predicate);
        Task DeleteAsync(int id);
        Task<List<T>> GetAsync();
        Task<T?> GetAsync(int id);
        void Update(T entity);
        IQueryable<T> Where(Func<T, bool> predicate);
    }
}
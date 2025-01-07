using Microsoft.EntityFrameworkCore.Storage;

namespace YMYPHibrit3GroupEFCore.API.Model.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync();
    }
}

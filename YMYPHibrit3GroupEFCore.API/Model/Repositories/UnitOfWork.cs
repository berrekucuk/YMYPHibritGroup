
using Microsoft.EntityFrameworkCore.Storage;
using YMYPHibrit3GroupEFCore.API.Model.Repositories.Entities;

namespace YMYPHibrit3GroupEFCore.API.Model.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            context.Database.CommitTransactionAsync();
        }
    }
}

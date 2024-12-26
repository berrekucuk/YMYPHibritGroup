using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YMYPHibrit3GroupEFCore.API.Model.Repositories.Configurations;

namespace YMYPHibrit3GroupEFCore.API.Model.Repositories.Entities
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductConfiguation());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            base.OnModelCreating(modelBuilder);
        }
    }
}

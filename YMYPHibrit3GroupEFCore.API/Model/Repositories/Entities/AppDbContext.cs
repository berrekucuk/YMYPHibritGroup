using Microsoft.EntityFrameworkCore;

namespace YMYPHibrit3GroupEFCore.API.Model.Repositories.Entities
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }


    }
}

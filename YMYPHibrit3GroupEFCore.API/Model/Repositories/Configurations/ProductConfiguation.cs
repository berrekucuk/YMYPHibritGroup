using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using YMYPHibrit3GroupEFCore.API.Model.Repositories.Entities;

namespace YMYPHibrit3GroupEFCore.API.Model.Repositories.Configurations
{
    public class ProductConfiguation : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Barcode).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");

            builder.Property(x => x.Stock).IsRequired();
        }
    }
}

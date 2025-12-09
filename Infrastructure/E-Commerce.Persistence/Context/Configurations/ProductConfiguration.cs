using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Context.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(x => x.Name).HasColumnType("VarChar")
                .HasMaxLength(256);


            builder.Property(x => x.PictureUrl).HasColumnType("VarChar")
                .HasMaxLength(256);


            builder.Property(x => x.Description).HasColumnType("VarChar")
                .HasMaxLength(512);


            builder.Property(x => x.Price).HasColumnType("Decimal(10,2)");

            builder.HasOne(p => p.ProductBrand).WithMany().HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(p => p.ProductType).WithMany().HasForeignKey(p => p.TypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}

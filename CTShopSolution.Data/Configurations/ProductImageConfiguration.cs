using System;
using System.Collections.Generic;
using System.Text;
using CTShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTShopSolution.Data.Configurations
{
   public class ProductImageConfiguration :IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.ImagePath).HasMaxLength(300).IsRequired(true);
            builder.Property(x => x.Caption).HasMaxLength(300).IsRequired(true);

            builder.HasOne(x => x.Product).WithMany(x => x.ProductImages).HasForeignKey(x => x.ProductId);
        }
    }
}

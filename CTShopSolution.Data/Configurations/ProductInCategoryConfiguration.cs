using System;
using System.Collections.Generic;
using System.Text;
using CTShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTShopSolution.Data.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            // cau hinh khoa ngoai
            
            builder.ToTable("ProductInCategories");
            builder.HasKey(t => new { t.CategoryId, t.ProductId });
            //Cau hinh khoa nhieu nhieu many to many
            // lien ket tu product toi nhieu category
            //Tro 2 khoa den product, category
            builder.HasOne(t => t.Product)
                .WithMany(pc => pc.ProductInCategories)
                .HasForeignKey((pc => pc.ProductId));


            builder.HasOne(t => t.Category)
                .WithMany(pc => pc.ProductInCategories)
                .HasForeignKey((pc => pc.CategoryId));
        }
    }
}

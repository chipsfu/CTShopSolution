﻿using CTShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTShopSolution.Data.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();


            builder.HasOne(x => x.Product).WithMany(x => x.Carts).HasForeignKey(x => x.ProductId);

            //sau khi them appuser vqao cart
            //AppUser cung chua co thuoc tinh nen phai them vao AppUser List<cart>
            builder.HasOne(x => x.AppUser).WithMany(x => x.Carts).HasForeignKey(x => x.UserId);

        }
    }
}

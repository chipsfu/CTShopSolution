using System;
using System.Collections.Generic;
using System.Text;
using CTShopSolution.Data.Entities;
using CTShopSolution.Data.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTShopSolution.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).HasDefaultValue(Status.Active);
            //throw new NotImplementedException();
        }
    }
}

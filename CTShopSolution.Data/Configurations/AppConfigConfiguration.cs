using System;
using System.Collections.Generic;
using System.Text;
using CTShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTShopSolution.Data.Configurations
{
    public class AppConfigConfiguration : IEntityTypeConfiguration<AppConfig>

    {
        //ke thua IEntityTypeConfiguration va implement interface
        public void Configure(EntityTypeBuilder<AppConfig> builder)
        {
            //cau hinh ten bang, thuoc tinh
            builder.ToTable("AppConfigs");

            builder.HasKey(x => x.Key);

            builder.Property(x => x.Value).IsRequired(true);
        }
    }
}

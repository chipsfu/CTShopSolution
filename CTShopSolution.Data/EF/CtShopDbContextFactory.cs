using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CTShopSolution.Data.EF
{
    public class CtShopDbContextFactory : IDesignTimeDbContextFactory<CtShopDbContext>
    {
        public CtShopDbContext CreateDbContext(string[] args)
        {

            //Add Microsoft.extensions.Config.FileExtensions
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("CTShopDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<CtShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CtShopDbContext(optionsBuilder.Options);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace RealEstateManager.Database
{
    public class RealEstateContextFactory : IDesignTimeDbContextFactory<RealEstateContext>
    {
        public RealEstateContext CreateDbContext(string[] args)
        {
            var configurations = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();

            var builder = new DbContextOptionsBuilder<RealEstateContext>();

            var connectionString = configurations.GetConnectionString("RealEstateDb");
            builder.UseSqlServer(connectionString);

            return new RealEstateContext(builder.Options);
        }
    }
}


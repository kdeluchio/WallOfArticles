using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace RockContent.Infra.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<RockContentContext>
    {
        public RockContentContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<RockContentContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
                                                                      
            builder.UseMySql(connectionString, optionsBuilder => optionsBuilder.ServerVersion(
                                                            new Version(5, 7, 19),
                                                            ServerType.MySql));

            return new RockContentContext(builder.Options);            
        }
    }
}
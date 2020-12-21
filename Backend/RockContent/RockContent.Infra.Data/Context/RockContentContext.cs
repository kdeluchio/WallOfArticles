using Microsoft.EntityFrameworkCore;
using RockContent.Domain.Models;
using RockContent.Infra.Data.Mapping;

namespace RockContent.Infra.Data.Context
{
    public class RockContentContext : DbContext
    {
        public DbSet<Article> Article { get; set; }

        public RockContentContext(DbContextOptions<RockContentContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMap()); 			

            base.OnModelCreating(modelBuilder);
        }

    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RockContent.Domain.Models;

namespace RockContent.Infra.Data.Mapping
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.HasKey(i => i.Id);

            builder.Property(c => c.Title)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Text)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(c => c.Likes)
                .HasColumnType("integer")
                .IsRequired();

        }
    }
}
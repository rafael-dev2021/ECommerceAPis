using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.InfraData.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CategoryName).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Category(1, "Dress"),
                new Category(2, "Blouse"),
                new Category(3, "Shirt"),
                new Category(4, "T-Shirt"),
                new Category(5, "Pants"),
                new Category(6, "Regatta")
                );
        }
    }
}

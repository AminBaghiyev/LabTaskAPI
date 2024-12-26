using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DAL.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasMany(e => e.OrderItems)
            .WithOne(e => e.Product)
            .HasForeignKey(e => e.ProductId);

        builder
            .Property(e => e.Price)
            .HasColumnType("decimal(10,2)");
    }
}

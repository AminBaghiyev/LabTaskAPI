using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkshopManagement.Core.Entities;

namespace WorkshopManagement.DAL.Configurations;

public class WorkshopConfiguration : IEntityTypeConfiguration<Workshop>
{
    public void Configure(EntityTypeBuilder<Workshop> builder)
    {
        builder
            .Property(p => p.Title)
            .HasMaxLength(100);

        builder
            .Property(p => p.Description)
            .HasMaxLength(500);

        builder
            .Property(p => p.Location)
            .HasMaxLength(200);
    }
}

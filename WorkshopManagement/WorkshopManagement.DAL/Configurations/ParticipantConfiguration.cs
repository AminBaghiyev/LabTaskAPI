using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkshopManagement.Core.Entities;

namespace WorkshopManagement.DAL.Configurations;

public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
{
    public void Configure(EntityTypeBuilder<Participant> builder)
    {
        builder
            .Property(p => p.Name)
            .HasMaxLength(100);

        builder
            .Property(p => p.Email)
            .HasMaxLength(150);

        builder
            .Property(p => p.Phone)
            .HasMaxLength(50);

        builder
            .HasOne(p => p.Workshop)
            .WithMany(w => w.Participants)
            .HasForeignKey(p => p.WorkshopId);
    }
}

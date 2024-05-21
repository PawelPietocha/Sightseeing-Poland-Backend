using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class MountainConfiguration : IEntityTypeConfiguration<Mountain>
    {
        public void Configure(EntityTypeBuilder<Mountain> builder)
        {
            builder.Property(m => m.Id).IsRequired();
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m => m.ImagePath).IsRequired();
            builder.HasOne(m => m.Voivodeship).WithMany()
                .HasForeignKey(m => m.VoivodeshipId);
            builder.HasOne(m => m.MountainsRange).WithMany()
                .HasForeignKey(m => m.MountainsRangeId);

        }
    }
}
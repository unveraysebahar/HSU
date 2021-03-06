using System;
using Microsoft.EntityFrameworkCore;
using AnimalHealthApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalHealthApp.Data.Concreate.EntityFramework.Mappings
{
    public class VeterinaryClinicMap : IEntityTypeConfiguration<VeterinaryClinic>
    {
        public void Configure(EntityTypeBuilder<VeterinaryClinic> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.Name).HasMaxLength(70);
            builder.Property(s => s.Description).HasMaxLength(500);
            builder.Property(s => s.CreatedByName).IsRequired();
            builder.Property(s => s.CreatedByName).HasMaxLength(50);
            builder.Property(s => s.ModifiedByName).IsRequired();
            builder.Property(s => s.ModifiedByName).HasMaxLength(50);
            builder.Property(s => s.CreatedDate).IsRequired();
            builder.Property(s => s.ModifiedDate).IsRequired();
            builder.Property(s => s.IsActive).IsRequired();
            builder.Property(s => s.IsDeleted).IsRequired();
            builder.Property(s => s.Note).HasMaxLength(500);
            builder.ToTable("VeterinaryClinics");
            builder.HasData(
                new VeterinaryClinic
            {
                Id = 1,
                Name = "A",
                Description = "A Description",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "A Note"
            }
            );
        }
    }
}

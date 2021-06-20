using AnimalHealthApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHealthApp.Data.Concreate.EntityFramework.Mappings
{
    public class VeterinarianMap : IEntityTypeConfiguration<Veterinarian>
    {
        public void Configure(EntityTypeBuilder<Veterinarian> builder)
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
            builder.HasOne<VeterinaryClinic>(v => v.VeterinaryClinic).WithMany(v => v.Veterinarians).HasForeignKey(v => v.VeterinaryClinicId);
            builder.ToTable("Veterinarians");
        }
    }
}

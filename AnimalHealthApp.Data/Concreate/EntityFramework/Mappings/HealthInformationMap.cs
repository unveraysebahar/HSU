using Microsoft.EntityFrameworkCore;
using AnimalHealthApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalHealthApp.Data.Concreate.EntityFramework.Mappings
{
    public class HealthInformationMap : IEntityTypeConfiguration<HealthInformation>
    {
        public void Configure(EntityTypeBuilder<HealthInformation> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Id).ValueGeneratedOnAdd();
            builder.Property(h => h.Title).IsRequired();
            builder.Property(h => h.Title).HasMaxLength(1000);
            builder.Property(h => h.ExaminationAndClinicalProcedure).IsRequired();
            builder.Property(h => h.ExaminationAndClinicalProcedure).HasMaxLength(250);
            builder.Property(h => h.DiagnosticImagingAndAdvancedDiagnosticMethod).IsRequired();
            builder.Property(h => h.DiagnosticImagingAndAdvancedDiagnosticMethod).HasMaxLength(250);
            builder.Property(h => h.SurgicalTreatment).IsRequired();
            builder.Property(h => h.SurgicalTreatment).HasMaxLength(250);
            builder.Property(h => h.VeterinaryDentistry).IsRequired();
            builder.Property(h => h.VeterinaryDentistry).HasMaxLength(250);
            builder.HasOne<Animal>(h => h.Animal).WithMany(h => h.HealthInformations).HasForeignKey(h => h.AnimalId);
            builder.Property(h => h.CreatedByName).IsRequired();
            builder.Property(h => h.CreatedByName).HasMaxLength(50);
            builder.Property(h => h.ModifiedByName).IsRequired();
            builder.Property(h => h.ModifiedByName).HasMaxLength(50);
            builder.Property(h => h.CreatedDate).IsRequired();
            builder.Property(h => h.ModifiedDate).IsRequired();
            builder.Property(h => h.IsActive).IsRequired();
            builder.Property(h => h.IsDeleted).IsRequired();
            builder.Property(h => h.Note).HasMaxLength(500);
            builder.ToTable("HealthInformations");
        }
    }
}

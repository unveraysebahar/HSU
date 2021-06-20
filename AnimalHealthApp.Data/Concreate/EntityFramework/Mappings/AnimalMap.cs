using Microsoft.EntityFrameworkCore;
using AnimalHealthApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalHealthApp.Data.Concreate.EntityFramework.Mappings
{
    public class AnimalMap : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(a => a.Id); // PrimaryKey
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).HasMaxLength(100); // Maximum of 100 characters
            builder.Property(a => a.Name).IsRequired(true);
            builder.Property(a => a.Type).IsRequired();
            builder.Property(a => a.Type).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.Breed).IsRequired();
            builder.Property(a => a.Breed).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.Age).IsRequired();
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.SeoVeterinary).IsRequired();
            builder.Property(a => a.SeoVeterinary).HasMaxLength(50);
            builder.Property(a => a.SeoDescription).HasMaxLength(150);
            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(70);
            builder.Property(a => a.ViewsHealthInformation).IsRequired();
            builder.Property(a => a.HealthInformationCount).IsRequired();
            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(250);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);
            builder.HasOne<VeterinaryClinic>(a => a.VeterinaryClinic).WithMany(s => s.Animals).HasForeignKey(a => a.VeterinaryClinicId);
            builder.HasOne<User>(a => a.User).WithMany(u => u.Animals).HasForeignKey(a => a.UserId);
            builder.ToTable("Animals");
        }
    }
}

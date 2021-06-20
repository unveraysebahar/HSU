using Microsoft.EntityFrameworkCore;
using AnimalHealthApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalHealthApp.Data.Concreate.EntityFramework.Mappings
{
    public class UserClaimMap : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            // Primary key
            builder.HasKey(uc => uc.Id);

            // Maps to the AspNetUserClaims table
            builder.ToTable("AspNetUserClaims");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using AnimalHealthApp.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AnimalHealthApp.Data.Concreate.EntityFramework.Mappings;

namespace AnimalHealthApp.Data.Concreate.EntityFramework.Contexts
{
    public class AnimalHealthAppContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Veterinarian> Veterinarians { get; set; }
        public DbSet<VeterinaryClinic> VeterinaryClinics { get; set; }
        public DbSet<HealthInformation> HealthInformations { get; set; }
        // public DbSet<Role> Roles { get; set; }
        // public DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.;Database=AnimalHealthApp;uid=sa;pwd=sa123;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
        //    // @"Server=(localdb)\ProjectsV13;Database=AnimalHealthApp;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;"
        //}

        public AnimalHealthAppContext(DbContextOptions<AnimalHealthAppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalMap());
            modelBuilder.ApplyConfiguration(new VeterinarianMap());
            modelBuilder.ApplyConfiguration(new VeterinaryClinicMap());
            modelBuilder.ApplyConfiguration(new HealthInformationMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleClaimMap());
            modelBuilder.ApplyConfiguration(new UserClaimMap());
            modelBuilder.ApplyConfiguration(new UserLoginMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
            modelBuilder.ApplyConfiguration(new UserTokenMap());
        }
    }
}

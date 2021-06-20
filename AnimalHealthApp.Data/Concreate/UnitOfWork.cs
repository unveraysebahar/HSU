using System.Threading.Tasks;
using AnimalHealthApp.Data.Absract;
using AnimalHealthApp.Data.Concreate.EntityFramework.Contexts;
using AnimalHealthApp.Data.Concreate.EntityFramework.Repositories;

namespace AnimalHealthApp.Data.Concreate
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AnimalHealthAppContext _context;
        private EfAnimalRepository _efAnimalRepository;
        private EfVeterinarianRepository _efVeterinarianRepository;
        private EfVeterinaryClinicRepository _efVeterinaryClinicRepository;
        private EfHealthInformationRepository _efHealthInformationRepository;
        // private EfRoleRepository _efRoleRepository;
        // private EfUserRepository _efUserRepository;

        public UnitOfWork(AnimalHealthAppContext context)
        {
            _context = context;
        }

        public IAnimalRepository Animals => _efAnimalRepository ?? new EfAnimalRepository(_context);
        public IVeterinarianRepository Veterinarians => _efVeterinarianRepository ?? new EfVeterinarianRepository(_context);
        public IVeterinaryClinicRepository VeterinaryClinics => _efVeterinaryClinicRepository ?? new EfVeterinaryClinicRepository(_context);
        public IHealthInformationRepository HealthInformations => _efHealthInformationRepository ?? new EfHealthInformationRepository(_context);
        // public IRoleRepository Roles => _efRoleRepository ?? new EfRoleRepository(_context);
        // public IUserRepository Users => _efUserRepository ?? new EfUserRepository(_context);

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync(); // Returns an integer
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}

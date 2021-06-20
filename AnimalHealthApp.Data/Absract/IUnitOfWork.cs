using System;
using System.Threading.Tasks;

namespace AnimalHealthApp.Data.Absract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IAnimalRepository Animals { get; }
        IVeterinarianRepository Veterinarians { get; }
        IVeterinaryClinicRepository VeterinaryClinics { get; }
        IHealthInformationRepository HealthInformations { get; }
        Task<int> SaveAsync();
    }
}

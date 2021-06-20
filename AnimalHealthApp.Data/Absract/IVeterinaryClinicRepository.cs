using System.Threading.Tasks;
using AnimalHealthApp.Entities.Concrete;
using AnimalHealthApp.Shared.Data.Abstract;

namespace AnimalHealthApp.Data.Absract
{
    public interface IVeterinaryClinicRepository : IEntityRepository<VeterinaryClinic>
    {
        Task<VeterinaryClinic> GetById(int veterinaryClinicId);
    }
}

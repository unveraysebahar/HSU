using System.Threading.Tasks;
using AnimalHealthApp.Data.Absract;
using Microsoft.EntityFrameworkCore;
using AnimalHealthApp.Entities.Concrete;
using AnimalHealthApp.Shared.Data.Concrete.EntityFramework;
using AnimalHealthApp.Data.Concreate.EntityFramework.Contexts;

namespace AnimalHealthApp.Data.Concreate.EntityFramework.Repositories
{
    public class EfVeterinaryClinicRepository : EfEntityRepositoryBase<VeterinaryClinic>, IVeterinaryClinicRepository
    {
        public EfVeterinaryClinicRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<VeterinaryClinic> GetById(int veterinaryClinicId)
        {
            return await AnimalHealthAppContext.VeterinaryClinics.SingleOrDefaultAsync(s => s.Id == veterinaryClinicId);
        }

        private AnimalHealthAppContext AnimalHealthAppContext
        {
            get
            {
                return _dbContext as AnimalHealthAppContext; // To find _dbContext
            }
        }
    }
}

using AnimalHealthApp.Data.Absract;
using Microsoft.EntityFrameworkCore;
using AnimalHealthApp.Entities.Concrete;
using AnimalHealthApp.Shared.Data.Concrete.EntityFramework;

namespace AnimalHealthApp.Data.Concreate.EntityFramework.Repositories
{
    public class EfHealthInformationRepository : EfEntityRepositoryBase<HealthInformation>, IHealthInformationRepository
    {
        public EfHealthInformationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}

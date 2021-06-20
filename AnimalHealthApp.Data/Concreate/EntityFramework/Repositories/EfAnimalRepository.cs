using AnimalHealthApp.Data.Absract;
using Microsoft.EntityFrameworkCore;
using AnimalHealthApp.Entities.Concrete;
using AnimalHealthApp.Shared.Data.Concrete.EntityFramework;

namespace AnimalHealthApp.Data.Concreate.EntityFramework.Repositories
{
    public class EfAnimalRepository : EfEntityRepositoryBase<Animal>, IAnimalRepository
    {
        public EfAnimalRepository(DbContext context) : base(context)
        {
        }
    }
}

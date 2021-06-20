using AnimalHealthApp.Data.Absract;
using AnimalHealthApp.Entities.Concrete;
using AnimalHealthApp.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHealthApp.Data.Concreate.EntityFramework.Repositories
{
    public class EfVeterinarianRepository : EfEntityRepositoryBase<Veterinarian>, IVeterinarianRepository
    {
        public EfVeterinarianRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}

using AnimalHealthApp.Entities.Concrete;
using AnimalHealthApp.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHealthApp.Data.Absract
{
    public interface IVeterinarianRepository : IEntityRepository<Veterinarian>
    {
    }
}

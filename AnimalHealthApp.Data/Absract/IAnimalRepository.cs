using AnimalHealthApp.Entities.Concrete;
using AnimalHealthApp.Shared.Data.Abstract;

namespace AnimalHealthApp.Data.Absract
{
    public interface IAnimalRepository : IEntityRepository<Animal>
    {
    }
}

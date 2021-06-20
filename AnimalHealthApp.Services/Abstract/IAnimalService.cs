using System.Threading.Tasks;
using AnimalHealthApp.Entities.Dtos;
using AnimalHealthApp.Shared.Utilities.Results.Abstract;

namespace AnimalHealthApp.Services.Abstract
{
    public interface IAnimalService
    {
        Task<IDataResult<AnimalDto>> GetAsync(int animalId); // AnimalId
        Task<IDataResult<AnimalListDto>> GetAllAsync();
        Task<IDataResult<AnimalListDto>> GetAllByNonDeletedAsync(); // Not deleted
        Task<IDataResult<AnimalListDto>> GetAllByNonDeletedAndActiveAsync(); // Not deleted and active
        Task<IDataResult<AnimalListDto>> GetAllByVeterinaryClinicAsync(int veterinaryClinicId); //Records by veterinary clinics
        Task<IResult> AddAsync(AnimalAddDto animalAddDto, string createdByName);
        Task<IResult> UpdateAsync(AnimalUpdateDto animalUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int animalId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int animalId); // To completely erase
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByIsDeletedAsync();
    }
}

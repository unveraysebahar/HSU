using System.Threading.Tasks;
using AnimalHealthApp.Entities.Dtos;
using AnimalHealthApp.Shared.Utilities.Results.Abstract;

namespace AnimalHealthApp.Services.Abstract
{
    public interface IVeterinaryClinicService
    {
        Task<IDataResult<VeterinaryClinicDto>> GetAsync(int veterinaryClinicId);
        Task<IDataResult<VeterinaryClinicUpdateDto>> GetVeterinaryClinicUpdateDtoAsync(int veterinaryClinicId);
        Task<IDataResult<VeterinaryClinicListDto>> GetAllAsync();
        Task<IDataResult<VeterinaryClinicListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<VeterinaryClinicListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IDataResult<VeterinaryClinicDto>> AddAsync(VeterinaryClinicAddDto veterinaryClinicAddDto, string createdByName);
        Task<IDataResult<VeterinaryClinicDto>> UpdateAsync(VeterinaryClinicUpdateDto veterinaryClinicUpdateDto, string modifiedByName);
        Task<IDataResult<VeterinaryClinicDto>> DeleteAsync(int veterinaryClinicId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int veterinaryClinicId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByIsDeletedAsync();
    }
}

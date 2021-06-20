using System;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using AnimalHealthApp.Data.Absract;
using AnimalHealthApp.Entities.Dtos;
using AnimalHealthApp.Entities.Concrete;
using AnimalHealthApp.Services.Abstract;
using AnimalHealthApp.Services.Utilities;
using AnimalHealthApp.Shared.Utilities.Results.Abstract;
using AnimalHealthApp.Shared.Utilities.Results.Concrete;
using AnimalHealthApp.Shared.Utilities.Results.ComplexTypes;

namespace AnimalHealthApp.Services.Concrete
{
    public class VeterinaryClinicManager : IVeterinaryClinicService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public VeterinaryClinicManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<VeterinaryClinicDto>> GetAsync(int veterinaryClinicId)
        {
            var veterinaryClinic = await _unitOfWork.VeterinaryClinics.GetAsync(s => s.Id == veterinaryClinicId, s => s.Animals);
            if(veterinaryClinic != null)
            {
                return new DataResult<VeterinaryClinicDto>(ResultStatus.Success, new VeterinaryClinicDto
                {
                    VeterinaryClinic = veterinaryClinic,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<VeterinaryClinicDto>(ResultStatus.Error, Messages.VeterinaryClinic.NotFound(isPlural:false), new VeterinaryClinicDto 
            {
                VeterinaryClinic = null,
                ResultStatus =ResultStatus.Error,
                Message = Messages.VeterinaryClinic.NotFound(isPlural: false)
            });
        }

        public async Task<IDataResult<VeterinaryClinicListDto>> GetAllAsync()
        {
            var veterinaryClinics = await _unitOfWork.VeterinaryClinics.GetAllAsync(null, s => s.Animals);
            if(veterinaryClinics.Count > -1)
            {
                return new DataResult<VeterinaryClinicListDto>(ResultStatus.Success, new VeterinaryClinicListDto
                {
                    VeterinaryClinics = veterinaryClinics,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<VeterinaryClinicListDto>(ResultStatus.Error, Messages.VeterinaryClinic.NotFound(isPlural: true), new VeterinaryClinicListDto
            {
                VeterinaryClinics = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.VeterinaryClinic.NotFound(isPlural: true)
            });
        }

        public async Task<IDataResult<VeterinaryClinicListDto>> GetAllByNonDeletedAsync()
        {
            var veterinaryClinics = await _unitOfWork.VeterinaryClinics.GetAllAsync(s => !s.IsDeleted, s => s.Animals);
            if (veterinaryClinics.Count > -1)
            {
                return new DataResult<VeterinaryClinicListDto>(ResultStatus.Success, new VeterinaryClinicListDto
                {
                    VeterinaryClinics = veterinaryClinics,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<VeterinaryClinicListDto>(ResultStatus.Error, Messages.VeterinaryClinic.NotFound(isPlural: true), new VeterinaryClinicListDto
            {
                VeterinaryClinics = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.VeterinaryClinic.NotFound(isPlural: true)
            });
        }

        public async Task<IDataResult<VeterinaryClinicDto>> AddAsync(VeterinaryClinicAddDto veterinaryClinicAddDto, string createdByName)
        {
            var veterinaryClinic = _mapper.Map<VeterinaryClinic>(veterinaryClinicAddDto);
            veterinaryClinic.CreatedByName = createdByName;
            veterinaryClinic.ModifiedByName = createdByName;
            var addedVeterinaryClinic = await _unitOfWork.VeterinaryClinics.AddAsync(veterinaryClinic);
            await _unitOfWork.SaveAsync();
            return new DataResult<VeterinaryClinicDto>(ResultStatus.Success, Messages.VeterinaryClinic.Add(addedVeterinaryClinic.Name), new VeterinaryClinicDto 
            {
                VeterinaryClinic = addedVeterinaryClinic,
                ResultStatus = ResultStatus.Success,
                Message = Messages.VeterinaryClinic.Add(addedVeterinaryClinic.Name)
            });
        }

        public async Task<IDataResult<VeterinaryClinicDto>> UpdateAsync(VeterinaryClinicUpdateDto veterinaryClinicUpdateDto, string modifiedByName)
        {
            var oldVeterinaryClinic = await _unitOfWork.VeterinaryClinics.GetAsync(s => s.Id == veterinaryClinicUpdateDto.Id);
            var veterinaryClinic = _mapper.Map<VeterinaryClinicUpdateDto, VeterinaryClinic>(veterinaryClinicUpdateDto, oldVeterinaryClinic);
            veterinaryClinic.ModifiedByName = modifiedByName;
            var updatedVeterinaryClinic = await _unitOfWork.VeterinaryClinics.UpdateAsync(veterinaryClinic);
            await _unitOfWork.SaveAsync();
            return new DataResult<VeterinaryClinicDto>(ResultStatus.Success, Messages.VeterinaryClinic.Update(updatedVeterinaryClinic.Name), new VeterinaryClinicDto
            {
                VeterinaryClinic = updatedVeterinaryClinic,
                ResultStatus = ResultStatus.Success,
                Message = Messages.VeterinaryClinic.Update(updatedVeterinaryClinic.Name)
            });
        }

        public async Task<IDataResult<VeterinaryClinicDto>> DeleteAsync(int veterinaryClinicId, string modifiedByName)
        {
            var veterinaryClinic = await _unitOfWork.VeterinaryClinics.GetAsync(s => s.Id == veterinaryClinicId);
            if(veterinaryClinic != null)
            {
                veterinaryClinic.IsDeleted = true;
                veterinaryClinic.ModifiedByName = modifiedByName;
                veterinaryClinic.ModifiedDate = DateTime.Now;
                var deletedVeterinaryClinic = await _unitOfWork.VeterinaryClinics.UpdateAsync(veterinaryClinic);
                await _unitOfWork.SaveAsync();
                return new DataResult<VeterinaryClinicDto>(ResultStatus.Success, Messages.VeterinaryClinic.Delete(deletedVeterinaryClinic.Name), new VeterinaryClinicDto
                {
                    VeterinaryClinic = deletedVeterinaryClinic,
                    ResultStatus = ResultStatus.Success,
                    Message = Messages.VeterinaryClinic.Delete(deletedVeterinaryClinic.Name)
                });
            }
            return new DataResult<VeterinaryClinicDto>(ResultStatus.Error, Messages.VeterinaryClinic.NotFound(isPlural: false), new VeterinaryClinicDto
            {
                VeterinaryClinic = null,
                ResultStatus = ResultStatus.Error,
                Message = Messages.VeterinaryClinic.NotFound(isPlural: false)
            });
        }

        public async Task<IResult> HardDeleteAsync(int veterinaryClinicId)
        {
            var veterinaryClinic = await _unitOfWork.VeterinaryClinics.GetAsync(s => s.Id == veterinaryClinicId);
            if (veterinaryClinic != null)
            {
                await _unitOfWork.VeterinaryClinics.DeleteAsync(veterinaryClinic);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.VeterinaryClinic.HardDelete(veterinaryClinic.Name));
            }
            return new Result(ResultStatus.Error, Messages.VeterinaryClinic.NotFound(isPlural: false));
        }

        public async Task<IDataResult<VeterinaryClinicListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var veterinaryClinic = await _unitOfWork.VeterinaryClinics.GetAllAsync(s => !s.IsDeleted && s.IsActive, s => s.Animals);
            if (veterinaryClinic.Count > -1)
            {
                return new DataResult<VeterinaryClinicListDto>(ResultStatus.Success, new VeterinaryClinicListDto
                {
                    VeterinaryClinics = veterinaryClinic,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<VeterinaryClinicListDto>(ResultStatus.Error, Messages.VeterinaryClinic.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<VeterinaryClinicUpdateDto>> GetVeterinaryClinicUpdateDtoAsync(int veterinaryClinicId)
        {
            var result = await _unitOfWork.VeterinaryClinics.AnyAsync(s => s.Id == veterinaryClinicId);
            if (result)
            {
                var veterinaryClinic = await _unitOfWork.VeterinaryClinics.GetAsync(s => s.Id == veterinaryClinicId);
                var veterinaryClinicUpdateDto = _mapper.Map<VeterinaryClinicUpdateDto>(veterinaryClinic);
                return new DataResult<VeterinaryClinicUpdateDto>(ResultStatus.Success, veterinaryClinicUpdateDto);
            }
            else
            {
                return new DataResult<VeterinaryClinicUpdateDto>(ResultStatus.Error, Messages.VeterinaryClinic.NotFound(isPlural: false) , null);
            }
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var veterinaryClinicCount = await _unitOfWork.VeterinaryClinics.CountAsync();
            if(veterinaryClinicCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, veterinaryClinicCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByIsDeletedAsync()
        {
            var veterinaryClinicCount = await _unitOfWork.VeterinaryClinics.CountAsync(s => !s.IsDeleted);
            if (veterinaryClinicCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, veterinaryClinicCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }
    }
}

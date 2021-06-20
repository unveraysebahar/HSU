using System;
using AutoMapper;
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
    public class AnimalManager : IAnimalService
    {
        // TODO: Organize messages using the Messages class.

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnimalManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<AnimalDto>> GetAsync(int animalId)
        {
            var animal = await _unitOfWork.Animals.GetAsync(a => a.Id == animalId, a => a.User, a => a.VeterinaryClinic);
            if(animal != null)
            {
                return new DataResult<AnimalDto>(ResultStatus.Success, new AnimalDto
                {
                    Animal = animal,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<AnimalDto>(ResultStatus.Error, Messages.Animal.NotFound(isPlural:false), null);
        }

        public async Task<IDataResult<AnimalListDto>> GetAllAsync()
        {
            var animals = await _unitOfWork.Animals.GetAllAsync(null, a => a.User, a => a.VeterinaryClinic);
            if(animals.Count >= -1)
            {
                return new DataResult<AnimalListDto>(ResultStatus.Success, new AnimalListDto
                {
                    Animals = animals,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<AnimalListDto>(ResultStatus.Error, Messages.Animal.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<AnimalListDto>> GetAllByVeterinaryClinicAsync(int veterinaryClinicId)
        {
            var result = await _unitOfWork.VeterinaryClinics.AnyAsync(s => s.Id == veterinaryClinicId);
            if (result)
            {
                var animals = await _unitOfWork.Animals.GetAllAsync(a => a.VeterinaryClinicId == veterinaryClinicId && !a.IsDeleted && a.IsActive, a => a.User, a => a.VeterinaryClinic);
                if (animals.Count >= -1)
                {
                    return new DataResult<AnimalListDto>(ResultStatus.Success, new AnimalListDto
                    {
                        Animals = animals,
                        ResultStatus = ResultStatus.Success
                    });
                }
                return new DataResult<AnimalListDto>(ResultStatus.Error, "Hayvanlar Bulunamadı.", null);
            }
            return new DataResult<AnimalListDto>(ResultStatus.Error, "Böyle bir Hayvan Türü Bulunamadı.", null);
        }

        public async Task<IDataResult<AnimalListDto>> GetAllByNonDeletedAsync()
        {
            var animals = await _unitOfWork.Animals.GetAllAsync(a => !a.IsDeleted, a => a.User, a => a.VeterinaryClinic);
            if (animals.Count >= -1)
            {
                return new DataResult<AnimalListDto>(ResultStatus.Success, new AnimalListDto
                {
                    Animals = animals,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<AnimalListDto>(ResultStatus.Error, "Hayvanlar Bulunamadı.", null);
        }

        public async Task<IDataResult<AnimalListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var animals = await _unitOfWork.Animals.GetAllAsync(a => !a.IsDeleted && a.IsActive, a => a.User, a => a.VeterinaryClinic);
            if (animals.Count >= -1)
            {
                return new DataResult<AnimalListDto>(ResultStatus.Success, new AnimalListDto
                {
                    Animals = animals,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<AnimalListDto>(ResultStatus.Error, "Hayvanlar Bulunamadı.", null);
        }

        public async Task<IResult> AddAsync(AnimalAddDto animalAddDto, string createdByName)
        {
            var animal = _mapper.Map<Animal>(animalAddDto);
            animal.CreatedByName = createdByName;
            animal.ModifiedByName = createdByName;
            animal.UserId = 1; // TODO: Fix here when session is added
            await _unitOfWork.Animals.AddAsync(animal);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{animalAddDto.Name} İsimli Hayvan Başarıyla Eklenmiştir.");
        }

        public async Task<IResult> UpdateAsync(AnimalUpdateDto animalUpdateDto, string modifiedByName)
        {
            var animal = _mapper.Map<Animal>(animalUpdateDto);
            animal.ModifiedByName = modifiedByName;
            await _unitOfWork.Animals.UpdateAsync(animal);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{animalUpdateDto.Name} İsimli Hayvan Başarıyla Güncellenmiştir.");
        }

        public async Task<IResult> DeleteAsync(int animalId, string modifiedByName)
        {
            var result = await _unitOfWork.Animals.AnyAsync(a => a.Id == animalId);
            if(result)
            {
                var animal = await _unitOfWork.Animals.GetAsync(a => a.Id == animalId);
                animal.IsDeleted = true;
                animal.ModifiedByName = modifiedByName;
                animal.ModifiedDate = DateTime.Now;
                await _unitOfWork.Animals.UpdateAsync(animal);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{animal.Name} İsimli Hayvan Başarıyla Silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir hayvan bulunamadı.");
        }

        public async Task<IResult> HardDeleteAsync(int animalId)
        {
            var result = await _unitOfWork.Animals.AnyAsync(a => a.Id == animalId);
            if (result)
            {
                var animal = await _unitOfWork.Animals.GetAsync(a => a.Id == animalId);
                await _unitOfWork.Animals.DeleteAsync(animal);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{animal.Name} İsimli Hayvan Başarıyla Veritabanından Silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir hayvan bulunamadı.");
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var animalsCount = await _unitOfWork.Animals.CountAsync();
            if (animalsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, animalsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByIsDeletedAsync()
        {
            var animalsCount = await _unitOfWork.Animals.CountAsync(a => !a.IsDeleted);
            if (animalsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, animalsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }
    }
}

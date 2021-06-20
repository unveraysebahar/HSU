using System.Threading.Tasks;
using AnimalHealthApp.Data.Absract;
using AnimalHealthApp.Services.Abstract;
using AnimalHealthApp.Shared.Utilities.Results.Abstract;
using AnimalHealthApp.Shared.Utilities.Results.Concrete;
using AnimalHealthApp.Shared.Utilities.Results.ComplexTypes;

namespace AnimalHealthApp.Services.Concrete
{
    public class HealthInformationManager : IHealthInformationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HealthInformationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var commentsCount = await _unitOfWork.HealthInformations.CountAsync();
            if (commentsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, commentsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByIsDeletedAsync()
        {
            var commentsCount = await _unitOfWork.HealthInformations.CountAsync(c => !c.IsDeleted);
            if (commentsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, commentsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }
    }
}
